using LockerEco.EcoMode;
using LockerEco.EcoMode.Notifications;
using LockerEco.LockerManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LockerEco.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EcoModeController : ControllerBase
    {
        private readonly ILogger<EcoModeController> _logger;
        private readonly IEcoModeManager _ecoModeManager;

        public EcoModeController(ILogger<EcoModeController> logger, IEcoModeManager ecoModeManager, IEmailService emailService, IDatabaseService databaseService, IBuildingManagementService buildingManagementService)
        {
            _logger = logger;
            _ecoModeManager = ecoModeManager;

            _ecoModeManager.ClearNotificationListeners();
            _ecoModeManager.RegisterNotificationListener(new EmailListenerAdapter(emailService));
            _ecoModeManager.RegisterNotificationListener(new DatabaseListenerAdapter(databaseService));
            _ecoModeManager.RegisterNotificationListener(new BuildingManagementListenerAdapter(buildingManagementService));
            _ecoModeManager.RegisterNotificationListener(new EmailListenerAdapter(emailService));
        }

        [HttpGet("on")]
        public async Task EcoModeOn()
        {
            await _ecoModeManager.TurnEcoModeOn();
        }

        [HttpGet("off")]
        public async Task EcoModeOff()
        {
            await _ecoModeManager.TurnEcoModeOff();
        }
    }
}
