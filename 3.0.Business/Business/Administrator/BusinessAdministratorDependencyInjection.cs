using _4._0.Repository.Repository;
using _5._0.DataAcces.Query;
using Microsoft.Extensions.DependencyInjection;

namespace _3._0.Business.Administrator;

public partial class BusinessAdministrator
{
    private IRepoAdministrator? _repoAdministrator {get;set;}
    
    protected override void InitDi()
    {
        _administrators.AddTransient<IRepoAdministrator,QAdministrator>();
        InitProvider();
        _repoAdministrator = _providerAdministrator.GetService<IRepoAdministrator>();
    }
}