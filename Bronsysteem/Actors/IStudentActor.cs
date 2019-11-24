using System.Threading.Tasks;
using Dapr.Actors;

namespace Bronsysteem.Actors
{
    public interface IStudentActor : IActor
    {
        Task<string> SetStudentAsync(Student employee);
        Task<Student> GetStudentAsync();
    }
}
