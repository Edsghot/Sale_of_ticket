using _4._0.Repository.Repository;
using _5._0.DataAcces.Query;
using Microsoft.Extensions.DependencyInjection;

namespace _3._0.Business.Producto
{
    public partial class BusinessProduct
    {
        private IRepoProduct? _repoProduct { get; set; }

        protected override void InitDi()
        {
            _products.AddTransient<IRepoProduct, QProduct>();
            InitProvider();
            _repoProduct = _providerProduct.GetService<IRepoProduct>();
        }
    }
}
