using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.LockerManager.Notifications
{
    interface IEmailService
    {
        Task SendEmail(IEnumerable<LockerState> states);
    }
}
