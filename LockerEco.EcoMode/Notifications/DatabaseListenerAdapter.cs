using LockerEco.LockerManager;
using LockerEco.LockerManager.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.EcoMode.Notifications
{
    public class DatabaseListenerAdapter : ILockerStateChangeNotifier
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
