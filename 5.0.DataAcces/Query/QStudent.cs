using _0._0.DataTransfer.DTO;
using _4._0.Repository.Repository;
using _5._0.DataAcces.Connection;
using _5._0.DataAcces.Entity;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace _5._0.DataAcces.Query
{
    public class QStudent : IRepoStudent
    {
        //Query para realizar la inserción de nuevos estudiantes 
        public int Insert(DtoStudent dto)
        {
            using DataBaseContext dbc = new();
            dbc.Students.Add(InitAutoMapper.mapper.Map<Student>(dto));
            return dbc.SaveChanges();
        }

        public string subirImagen(IFormFile file,String id)
        {
  
            Account account = new Account("dgbtcphdn", "728643729924779", "DMdxKePAodC3cJ8tXQTxUeOT1mY");
            Cloudinary cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;

            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                    PublicId = id,
                    Folder = "venta_ticket/Student"

                    
            };

                
                var respuesta = cloudinary.Upload(uploadParams);

                //actualizando en la base de datos 
                using DataBaseContext dbc = new();
                Student student = dbc.Students.Find(id);

                    student = dbc.Students.Find(id);

                    if (student != null)
                    {
                        // Actualizando el atributo con la URL de la imagen
                        student.profileImg = respuesta.SecureUrl.AbsoluteUri;

                        dbc.SaveChanges();

                        return respuesta.SecureUrl.AbsoluteUri;
                    }
                    else
                    {
                        // El estudiante no fue encontrado en la base de datos
                        return "El estudiante no fue encontrado.";
                    }
            }
        }

        //Query para realizar el listado de los estudiantes de la base de datos
        public List<DtoStudent> GetAll()
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoStudent>>(dbc.Students.OrderBy(ob => ob.name).ToList());
        }

        //Query para realizar el listado de los estudiantes por su id de estudiante
        public List<DtoStudent> GetById(string id) 
        { 
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoStudent>>(dbc.Students.Where(w => w.idStudent == id).ToList());
        }

        //Query para verificar la existencia del estudiante por su código
        public bool ExistsByCode(string code)
        {
            using DataBaseContext dbc = new();
            return dbc.Students.Where(w => w.code == code).Any();
        }
        
        //Query para verificar la existencia del estudiante por su id
        public bool ExistsById(string idStudent)
        {
            using DataBaseContext dbc = new();
            return dbc.Students.Where(w => w.idStudent == idStudent).Any();
        }

        //Query para realizar la eliminación del estudiante
        public int Delete(string idStudent)
        {
            using DataBaseContext dbc = new();
            Student student = dbc.Students.Find(idStudent);

            if (student is null)
            {
                return 0;
            }

            dbc.Students.Remove(student);
            return dbc.SaveChanges();
        }

        //Query para realizar la actualización de la información del estudiante
        public int Update(DtoStudent dto)
        {
            using DataBaseContext dbc = new();
            Student student = dbc.Students.Find(dto.idStudent);
            student.dni = dto.dni;
            student.name = dto.name;
            student.lastName = dto.lastName;
            student.condition = dto.condition;
            student.school = dto.school;
            student.faculty = dto.faculty;
            student.disability = dto.disability;
            student.phone = dto.phone;
            student.address = dto.address;
            student.sex = dto.sex;
            student.studentState = dto.studentState;
            student.password = dto.password;
            student.mail = dto.mail;
            student.code = dto.code;
            return dbc.SaveChanges();
        }

        public string Login(string mail, string password)
        {
            using DataBaseContext dbc = new();
            return dbc.Students.Where(w => w.mail == mail && w.password == password).Select(s => s.idStudent).FirstOrDefault();
        }

    }
}