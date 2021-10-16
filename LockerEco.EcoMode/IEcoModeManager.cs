using LockerEco.LockerManager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.EcoMode
{
    public interface IEcoModeManager
    {
        public Task TurnEcoModeOn();

        public Task TurnEcoModeOff();

        public void RegisterNotificationListener(Func<IEnumerable<LockerState>, Task> listener);
    }
}