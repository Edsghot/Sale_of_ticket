using _0._0.DataTransfer.DtoAdditional;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _2._0.Service.Generic
{
    public abstract class ControllerGeneric<So,B>:Controller
    {
        protected B _business { get; set; }
        protected So _so { get; set; }

        protected ControllerGeneric()
        //codigo olor: El elemento propiedad "_business" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
        {
            _business = (B)Activator.CreateInstance(typeof(B), Array.Empty<object>());
            //codigo olor: Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            //Posible asignación de referencia nula.
            _so = (So)Activator.CreateInstance(typeof(So), Array.Empty<object>());
            //codigo olor: Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            //Posible asignación de referencia nula.
        }

        protected DtoMessage ValidatePartDto(object model, string[] fieldList)
        {
            DtoMessage dtoMessage = new();
            List<string> errors = null;
            //codigo olor: Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            ModelState.Clear();
            TryValidateModel(model);

            foreach (string item in fieldList)
            {
                ModelState.TryGetValue(item, out ModelStateEntry modelState);
                //codigo olor: Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL

                if (modelState is not null && modelState.Errors.Count > 0)
                {
                    errors = new();
                    errors.AddRange(modelState.Errors.Select(s => s.ErrorMessage).ToList());
                    break;
                }
            }

            if (errors is not null && errors.Count > 0)
            {
                dtoMessage.listMessage = errors;
            }

            return dtoMessage;
        }
    }
}
