using _4._0.Repository.Repository;
using _5._0.DataAcces.Query;
using Microsoft.Extensions.DependencyInjection;

namespace _3._0.Business.AdministratorOpening
{
    public partial class BusinessAdministratorOpening
    {
        private IRepoAdministratorOpening? _repoAdministratorOpening {get;set;}

        protected override void InitDi()
         {
            _administratoropenings.AddTransient<IRepoAdministratorOpening,QAdministratorOpening>();
            InitProvider();
            _repoAdministratorOpening = _providerAdministratorOpening.GetService<IRepoAdministratorOpening>();
        }
    }
}