using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.LockerManager.Notifications
{
    public interface IBuildingManagementService
    {
        Task ManagerLockerStateChanges(IEnumerable<LockerState> lockerStates);
    }
}
