using LockerEco.EcoMode.Notifications;
using LockerEco.LockerManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LockerEco.EcoMode
{
    internal class EcoModeManager : IEcoModeManager
    {
        private ILockerSystemManager _lockerManager;
        private Dictionary<ILockerStateChangeNotifier, NotificationListenerState> _notificationListeners = new Dictionary<ILockerStateChangeNotifier, NotificationListenerState>();

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
            _notificationListeners.Add(listener, NotificationListenerState.Enabled);
        }

        public void RemoveNotificationListener(ILockerStateChangeNotifier listener)
        {
            _notificationListeners.Remove(listener);
        }

        public void ClearNotificationListeners()
        {
            _notificationListeners.Clear();
        }

        public void EnableNotificationListener(ILockerStateChangeNotifier listener)
        {
            if(!_notificationListeners.ContainsKey(listener))
            {
                throw new InvalidOperationException("The passed listener is not registered therefore no state change is possible.");
            }

            _notificationListeners[listener] = NotificationListenerState.Enabled;
        }

        public void DisableNotificationListener(ILockerStateChangeNotifier listener)
        {
            if (!_notificationListeners.ContainsKey(listener))
            {
                throw new InvalidOperationException("The passed listener is not registered therefore no state change is possible.");
            }

            _notificationListeners[listener] = NotificationListenerState.Disabled;
        }

        private async Task NotifyListenersAsync(IEnumerable<LockerState> states)
        {
            IEnumerable<Task> tasks = _notificationListeners.Where(x => x.Value == NotificationListenerState.Enabled)
                                                            .Select(x => x.Key.Notify(states));

            await Task.WhenAll(tasks);
        }
    }
}
