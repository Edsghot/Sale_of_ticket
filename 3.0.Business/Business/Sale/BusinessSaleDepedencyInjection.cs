using _4._0.Repository.Repository;
using _5._0.DataAcces.Query;
using Microsoft.Extensions.DependencyInjection;

namespace _3._0.Business.Business.Sale
{
    public partial class BusinessSale
    {
        private IRepoSale?  _repoSale {get;set;}
       
        protected override void InitDi()
        {
            _sales.AddTransient<IRepoSale,QSale>();
            InitProvider();
            _repoSale = _providerSale.GetService<IRepoSale>();
        }
    }
}