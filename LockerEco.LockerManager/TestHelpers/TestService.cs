using LockerEco.LockerManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LockerEco.LockerManager.TestHelpers
{
    internal class TestService : IDatabaseService, IEmailService, IBuildingManagementService
    {
        public Task ManagerLockerStateChanges(IEnumerable<LockerState> lockerStates)
        {
            TestMethod(nameof(ManagerLockerStateChanges), lockerStates);

            return Task.CompletedTask;
        }

        public Task SaveLockerStates(IEnumerable<LockerState> lockerStates)
        {
            TestMethod(nameof(SaveLockerStates), lockerStates);

            return Task.CompletedTask;
        }

        public Task SendEmail(IEnumerable<LockerState> states)
        {
            TestMethod(nameof(SendEmail), states);

            return Task.CompletedTask;
        }

        private void TestMethod(string callerName, IEnumerable<LockerState> states)
        {
            Console.WriteLine($"{callerName} received {states.Count()} locker states: {string.Join(", ", states.Select(x => x.RunsInEco))}");
        }
    }
}
