using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.LockerManager.Services
{
    public interface IDatabaseService
    {
        Task SaveLockerStates(IEnumerable<LockerState> lockerStates);
    }
}
