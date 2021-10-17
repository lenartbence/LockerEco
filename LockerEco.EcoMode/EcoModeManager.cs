using LockerEco.EcoMode.Notifications;
using LockerEco.LockerManager;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LockerEco.EcoMode
{
    internal class EcoModeManager : IEcoModeManager
    {
        private ILockerSystemManager _lockerManager;
        private List<ILockerStateChangeNotifier> _notificationListeners = new List<ILockerStateChangeNotifier>();

        public EcoModeManager(ILockerSystemManager lockerManager)
        {
            _lockerManager = lockerManager;
        }

        public async Task TurnEcoModeOn()
        {
            IEnumerable<LockerState> result = await _lockerManager.SwitchEcoOn();
            await NotifyListenersAsync(result);
        }

        public async Task TurnEcoModeOff()
        {
            IEnumerable<LockerState> result = await _lockerManager.SwitchEcoOff();
            await NotifyListenersAsync(result);
        }

        public void RegisterNotificationListener(ILockerStateChangeNotifier listener)
        {
            _notificationListeners.Add(listener);
        }

        public void RemoveNotificationListener(ILockerStateChangeNotifier listener)
        {
            _notificationListeners.Remove(listener);
        }

        public void ClearNotificationListeners()
        {
            _notificationListeners.Clear();
        }

        private async Task NotifyListenersAsync(IEnumerable<LockerState> states)
        {
            IEnumerable<Task> tasks = _notificationListeners.Select(x => x.Notify(states));
            await Task.WhenAll(tasks);
        }
    }
}
