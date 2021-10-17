using LockerEco.LockerManager;
using LockerEco.LockerManager.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.EcoMode.Notifications
{
    public class EmailListenerAdapter : ILockerStateChangeNotifier
    {
        private IEmailService _service;

        public EmailListenerAdapter(IEmailService service)
        {
            _service = service;
        }

        public async Task Notify(IEnumerable<LockerState> states)
        {
            await _service.SendEmail(states);
        }
    }
}
