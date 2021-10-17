using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.LockerManager.Services
{
    public interface IBuildingManagementService
    {
        Task ManagerLockerStateChanges(IEnumerable<LockerState> lockerStates);
    }
}
