using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bronsysteem;
using Bronsysteem.Actors;
using Dapr.Actors;
using Dapr.Actors.Runtime;

namespace BronActors.Actors
{
    public class EmployeeActor : Actor, IEmployeeActor
    {
        public EmployeeActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
        }

        public async Task<string> SetEmployeeAsync(Employee employee)
        {
            await this.StateManager.SetStateAsync("employee", employee);

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(employee));

            return "success";
        }

        public Task<Employee> GetEmployeeAsync()
        {
            return this.StateManager.GetStateAsync<Employee>("employee");
        }

        /// <summary>
        /// This method is called whenever an actor is activated.
        /// An actor is activated the first time any of its methods are invoked.
        /// </summary>
        protected override Task OnActivateAsync()
        {
            // Provides opportunity to perform some optional setup.
            Console.WriteLine($"Activating actor id: {this.Id}");
            return Task.CompletedTask;
        }

        /// <summary>
        /// This method is called whenever an actor is deactivated after a period of inactivity.
        /// </summary>
        protected override Task OnDeactivateAsync()
        {
            // Provides Opporunity to perform optional cleanup.
            Console.WriteLine($"Deactivating actor id: {this.Id}");
            return Task.CompletedTask;
        }

    }
}
