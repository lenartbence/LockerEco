using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.LockerManager.Notifications
{
    public interface IEmailService
    {
        Task SendEmail(IEnumerable<LockerState> states);
    }
}
