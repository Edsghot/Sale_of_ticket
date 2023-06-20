using _4._0.Repository.Repository;
using _5._0.DataAcces.Query;
using Microsoft.Extensions.DependencyInjection;

namespace _3._0.Business.Opening
{
    public partial class BusinessOpening
    {
        private IRepoOpening? _repoOpening {get;set;}

        protected override void InitDi()
        {
            _openings.AddTransient<IRepoOpening,QOpening>();
            InitProvider();
            _repoOpening = _providerOpening.GetService<IRepoOpening>();
        }
    }
}