using System;
using System.Threading.Tasks;
using Bronsysteem;
using Bronsysteem.Actors;
using Bronsysteem.Events;
using Dapr.Actors;
using Dapr.Actors.Runtime;
using Refit;

namespace BronActors.Actors
{
    public class StudentActor : Actor, IStudentActor
    {
        private const string stateName = "student";
        private readonly IDaprPublishApi daprPublishApi;

        public StudentActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
            this.daprPublishApi = RestService.For<IDaprPublishApi>("http://localhost:3500/v1.0");
        }

        public async Task<string> SetStudentAsync(Student student)
        {
            if (!(await StateManager.ContainsStateAsync(stateName)))
            {
                await daprPublishApi.PublishTopic("StudentEvent", new StudentEvent(student.Guid, action.Add));
            }

            await this.StateManager.SetStateAsync(stateName, student);

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(student));

            return "success";
        }

        public Task<Student> GetStudentAsync()
        {
            return this.StateManager.GetStateAsync<Student>(stateName);
        }
    }
}
