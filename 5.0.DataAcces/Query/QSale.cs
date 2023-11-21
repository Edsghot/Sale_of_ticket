using _0._0.DataTransfer.DTO;
using _4._0.Repository.Repository;
using _5._0.DataAcces.Connection;
using _5._0.DataAcces.Entity;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _5._0.DataAcces.Query
{
    public class QSale : IRepoSale
    {
        //Query para realizar la inserción de venta 
        public string Insert(DtoSale dto)
        {
            try
            {
                using DataBaseContext dbc = new();
                dbc.Sales.Add(InitAutoMapper.mapper.Map<Sale>(dto));
                dbc.SaveChanges();
                return dto.idSale;
            }
            catch(Exception e)
            {
                return "error al subir";
            }
        }
        public string subirImagen(IFormFile file, String id)
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
                    Folder = "venta_ticket/SaleTicket"


                };


                var respuesta = cloudinary.Upload(uploadParams);

                //actualizando en la base de datos 
                using DataBaseContext dbc = new();
                Sale sale = dbc.Sales.Find(id);

                if (sale != null)
                {
                    // Actualizando el atributo con la URL de la imagen
                    sale.couponImg = respuesta.SecureUrl.AbsoluteUri+"";

                    dbc.SaveChanges();

                    return respuesta.SecureUrl.AbsoluteUri;
                }
                else
                {
                    // El estudiante no fue encontrado en la base de datos
                    return "Error al registrar el sale";
                }
            }
        }

        public List<DtoSaleView> GetSale()
        {
            try
            {
                using (DataBaseContext dbc = new DataBaseContext())
                {
                    var query = from sale in dbc.Sales
                                join student in dbc.Students on sale.idStudent equals student.idStudent
                                select new DtoSaleView
                                {
                                    idSale = sale.idSale,
                                    couponImg = sale.couponImg,
                                    code = student.code,
                                    school = student.school,
                                    names = student.name + " " + student.lastName,
                                    saleState = sale.saleState
                                };

                    var results = query.OrderBy(s => s.idSale).ToList();

                    return results;
                }
            }
            catch (Exception e)
            {
                // Manejo del error
                Console.WriteLine(e.Message);
                return null; // O devuelve una lista vacía dependiendo de tus necesidades
            }
        }






        //Query para realizar el listado de las ventas realizadas
        public List<DtoSale> GetAll()
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoSale>>(dbc.Sales.OrderBy(ob => ob.idSale).ToList());
        }

        //Query para verificar la existencia de la venta por su id
        public bool ExistsById(string idSale)
        {
            using DataBaseContext dbc = new();
            return dbc.Sales.Where(w => w.idSale == idSale).Any();
        }

        //Query para realizar el listado de las ventas por del Id
        public List<DtoSale> GetById(string idSale)
        {
            using DataBaseContext dbc = new();
            return InitAutoMapper.mapper.Map<List<DtoSale>>(dbc.Sales.Where(w => w.idSale == idSale).ToList());
        }

        //Query para realizar el listado de las ventas por del IdStudent
        public List<DtoSale> GetByIdStudent(string idStudent)
        {
            using (DataBaseContext dbc = new DataBaseContext())
            {
                var sales = dbc.Sales.Where(w => w.idStudent.Equals(idStudent)).ToList();
                return InitAutoMapper.mapper.Map<List<DtoSale>>(sales);
            }
        }

        //Query para realizar la eliminación de la venta
        public int Delete(string idSale)
        {
            using DataBaseContext dbc = new();
            Sale sale = dbc.Sales.Find(idSale);

            if (sale is null)
            {
                return 0;
            }

            dbc.Sales.Remove(sale);
            return dbc.SaveChanges();
        }

        //Query para realizar la actualización de la información del producto
        public int Update(DtoSale dto)
        {
            using DataBaseContext dbc = new();
            Sale sale = dbc.Sales.Find(dto.idSale);
            sale.idStudent = dto.idStudent;
            sale.idPeriod = dto.idPeriod;
            sale.couponImg = dto.couponImg;
            sale.saleState = dto.saleState;
            return dbc.SaveChanges();
        }
        public int checkState(string id)
        {
            using DataBaseContext dbc = new();
            Sale sale = dbc.Sales.Find(id);
            sale.saleState = 1;
            return dbc.SaveChanges();
        }
    }
}