using LockerEco.EcoMode.Notifications;
using System.Threading.Tasks;

namespace LockerEco.EcoMode
{
    public interface IEcoModeManager
    {
        public Task TurnEcoModeOn();

        public Task TurnEcoModeOff();

        public void RegisterNotificationListener(ILockerStateChangeNotifier listener);

        public void RemoveNotificationListener(ILockerStateChangeNotifier listener);

        public void ClearNotificationListeners();

        public void EnableNotificationListener(ILockerStateChangeNotifier listener);

        public void DisableNotificationListener(ILockerStateChangeNotifier listener);
    }
}