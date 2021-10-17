using LockerEco.LockerManager;
using LockerEco.LockerManager.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.EcoMode.Notifications
{
    internal class DatabaseListenerAdapter : ILockerStateChangeNotifier
    {
        private IDatabaseService _service;

        public DatabaseListenerAdapter(IDatabaseService service)
        {
            _service = service;
        }

        public async Task Notify(IEnumerable<LockerState> states)
        {
            await _service.SaveLockerStates(states);
        }
    }
}
