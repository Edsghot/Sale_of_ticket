using _4._0.Repository.Repository;
using _5._0.DataAcces.Query;
using Microsoft.Extensions.DependencyInjection;

namespace _3._0.Business.Business.Period
{
    public partial class BusinessPeriod
    {
        private IRepoPeriod? _repoPeriod {get;set;}

        protected override void InitDi()
        {
            _periods.AddTransient<IRepoPeriod,QPeriod>();
            InitProvider();
            _repoPeriod = _providerPeriod.GetService<IRepoPeriod>();
        }
    }
}