using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.DtoAdditional;
using _3._0.Business.Generic;


namespace _3._0.Business.Administrator;

public partial class BusinessAdministrator : BusinessGeneric
{
   public DtoMessage Insert(DtoAdministrator dto){
        
        dto.idAdministrator = Guid.NewGuid().ToString();        
        ValidationInsertE(dto);

        if(_mo.existsMessage()){
            return _mo;
        }

        _repoAdministrator.Insert(dto);
        _mo.listMessage.Add("operacion realizada");
        _mo.success();
        return _mo;
    }

    public (DtoMessage, List<DtoAdministrator>) GetAll()
    {
        List<DtoAdministrator> listDtoAdministrator = _repoAdministrator.GetAll();
        _mo.success();
        return (_mo, listDtoAdministrator);
    }

    public List<DtoAdministrator> GetById(string id)
    {
       return _repoAdministrator.GetById(id);
     }

    public DtoMessage Delete(string id){
        ValidationById(id);
        if (_mo.existsMessage())
        {
            return _mo;
        }    
        _repoAdministrator.Delete(id);
        _mo.listMessage.Add("Operacion exitosa");
        _mo.success();
        return _mo;
    }
    public DtoMessage Update(DtoAdministrator dto){
        ValidationById(dto.idAdministrator);

        if (_mo.existsMessage())
        {
            return _mo;
        }

        _repoAdministrator.Update(dto);
        _mo.listMessage.Add("Operacion exitosa");
        _mo.success();
        return _mo;
    }

    public string Login(string mail, string password)
    {
        return _repoAdministrator.Login(mail, password);
    } 
}