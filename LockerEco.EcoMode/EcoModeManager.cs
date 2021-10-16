using LockerEco.LockerManager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.EcoMode
{
    internal class EcoModeManager : IEcoModeManager
    {
        private ILockerSystemManager _lockerManager;
        private IList<Func<IEnumerable<LockerState>, Task>> _notificationListeners = new List<Func<IEnumerable<LockerState>, Task>>();

        public EcoModeManager(ILockerSystemManager lockerManager)
        {
            _lockerManager = lockerManager;
        }

        public async Task TurnEcoModeOn()
        {
            IEnumerable<LockerState> result = await _lockerManager.SwitchEcoOn();
            await NotifyNotificationListenersAsync(result);
        }

        public async Task TurnEcoModeOff()
        {
            IEnumerable<LockerState> result = await _lockerManager.SwitchEcoOff();
            await NotifyNotificationListenersAsync(result);
        }

        public void RegisterNotificationListener(Func<IEnumerable<LockerState>, Task> listener)
        {
            _notificationListeners.Add(listener);
        }

        private async Task NotifyNotificationListenersAsync(IEnumerable<LockerState> states)
        {
            foreach (var listener in _notificationListeners)
            {
                await listener(states);
            }
        }
    }
}
