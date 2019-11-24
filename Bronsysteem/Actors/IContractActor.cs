using System.Threading.Tasks;
using Dapr.Actors;

namespace Bronsysteem.Actors
{
    public interface IContractActor : IActor
    {
        Task<string> SetContractAsync(Contract employee);
        Task<Contract> GetContractAsync();
    }
}
