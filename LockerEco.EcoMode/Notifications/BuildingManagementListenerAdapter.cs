using LockerEco.LockerManager;
using LockerEco.LockerManager.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.EcoMode.Notifications
{
    internal class BuildingManagementListenerAdapter : ILockerStateChangeNotifier
    {
        private IBuildingManagementService _service;

        public BuildingManagementListenerAdapter(IBuildingManagementService service)
        {
            _service = service;
        }

        public async Task Notify(IEnumerable<LockerState> states)
        {
            await _service.ManagerLockerStateChanges(states);
        }
    }
}
