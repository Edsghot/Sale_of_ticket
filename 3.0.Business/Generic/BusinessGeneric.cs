using _0._0.DataTransfer.DtoAdditional;
using Microsoft.Extensions.DependencyInjection;

namespace _3._0.Business.Generic
{
    public abstract class BusinessGeneric
    {
        protected DtoMessage _mo;
        protected ServiceCollection _students;
        protected ServiceCollection _products;
        protected ServiceCollection _administrators;
        protected ServiceCollection _periods;
        protected ServiceCollection _administratoropenings;
        protected ServiceCollection _openings;
        protected ServiceCollection _sales;
        protected ServiceCollection _saledetails;
        protected ServiceProvider _providerPeriod;
        protected ServiceProvider _providerStudent;
        protected ServiceProvider _providerProduct;
        protected ServiceProvider _providerAdministrator;
        protected ServiceProvider _providerAdministratorOpening;
        protected ServiceProvider _providerOpening;
        protected ServiceProvider _providerSale;
        protected ServiceProvider _providerSaleDetail;

        protected BusinessGeneric()
        //codigo olor: El elemento campo "_providerPeriod" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento campo como que admite un valor NULL.
        {
            _students = new();
            _products = new();
            _administrators = new();
            _periods = new();
            _administratoropenings = new();
            _openings = new();
            _sales = new();
            _saledetails = new();
            _mo = new();

            InitDi();
            //codigo olor: Quite esta llamada de un constructor al método 'InitDi' reemplazable.
        }

        protected virtual void InitDi() { }

        protected void InitProvider()
        {
            _providerPeriod = _periods.BuildServiceProvider();
            _providerStudent = _students.BuildServiceProvider();
            _providerProduct = _products.BuildServiceProvider();
            _providerAdministrator = _administrators.BuildServiceProvider();
            _providerAdministratorOpening = _administratoropenings.BuildServiceProvider();
            _providerOpening = _openings.BuildServiceProvider();
            _providerSale = _sales.BuildServiceProvider();
            _providerSaleDetail = _saledetails.BuildServiceProvider();
        }
    }
}