using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.LockerManager.Notifications
{
    interface IDatabaseService
    {
        Task SaveLockerStates(IEnumerable<LockerState> lockerStates);
    }
}
