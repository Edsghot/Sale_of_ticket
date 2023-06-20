using _4._0.Repository.Repository;
using _5._0.DataAcces.Query;
using Microsoft.Extensions.DependencyInjection;

namespace _3._0.Business.Student;

public partial class BusinessStudent
{
    private IRepoStudent? _repoStudent {get;set;}

    protected override void InitDi()
    {
        _students.AddTransient<IRepoStudent,QStudent>();
        InitProvider();
        _repoStudent = _providerStudent.GetService<IRepoStudent>();
    }
}