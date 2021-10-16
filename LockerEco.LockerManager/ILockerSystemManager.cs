using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.LockerManager
{
    public interface ILockerSystemManager
    {
        Task<IEnumerable<LockerState>> SwitchEcoOn();

        Task<IEnumerable<LockerState>> SwitchEcoOff();
    }
}
