using System.Threading.Tasks;
using Dapr.Actors;

namespace Bronsysteem.Actors
{
    public interface IEmployeeActor : IActor
    {
        Task<string> SetEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeAsync();
    }
}
