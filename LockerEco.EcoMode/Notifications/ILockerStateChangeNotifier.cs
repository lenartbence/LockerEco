using LockerEco.LockerManager;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.EcoMode.Notifications
{
    public interface ILockerStateChangeNotifier
    {
        Task Notify(IEnumerable<LockerState> states);
    }
}
