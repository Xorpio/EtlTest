using System.Threading.Tasks;
using Refit;

namespace Bronsysteem
{
    public interface IDaprPublishApi
    {
        [Post("/publish/{topicName}")]
        Task PublishTopic(string topicName, object payload);
    }
}
