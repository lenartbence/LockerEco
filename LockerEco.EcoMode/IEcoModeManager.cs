using LockerEco.EcoMode.Notifications;
using LockerEco.LockerManager.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.EcoMode
{
    public interface IEcoModeManager
    {
        public Task TurnEcoModeOn();

        public Task TurnEcoModeOff();

        public void RegisterNotificationListener(ILockerStateChangeNotifier listener);

        public void RemoveNotificationListener(ILockerStateChangeNotifier listener);
    }
}