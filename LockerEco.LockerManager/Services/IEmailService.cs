using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.LockerManager.Services
{
    public interface IEmailService
    {
        Task SendEmail(IEnumerable<LockerState> states);
    }
}
