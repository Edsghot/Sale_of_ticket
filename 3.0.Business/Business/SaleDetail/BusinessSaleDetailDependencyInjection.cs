using Microsoft.Extensions.DependencyInjection;
using _4._0.Repository.Repository;
using _5._0.DataAcces.Query;

namespace _3._0.Business.Business.SaleDetail;

    public partial class BusinessSaleDetail
    {
        private IRepoSaleDetail? _repoSaleDetail {get;set;}

    protected override void InitDi()
        {
            _saledetails.AddTransient<IRepoSaleDetail,QSaleDetail>();
            InitProvider();
            _repoSaleDetail = _providerSaleDetail.GetService<IRepoSaleDetail>();
    }
}
