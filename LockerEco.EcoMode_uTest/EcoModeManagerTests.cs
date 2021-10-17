using LockerEco.EcoMode;
using LockerEco.EcoMode.Notifications;
using LockerEco.LockerManager;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LockerEco.EcoMode_uTest
{
    public class EcoModeManagerTests
    {
        private EcoModeManager _manager;
        private Mock<ILockerSystemManager> _lockerManagerMock;

        [SetUp]
        public void Setup()
        {
            _lockerManagerMock = new Mock<ILockerSystemManager>();
            _manager = new EcoModeManager(_lockerManagerMock.Object);
        }

        [Test]
        public async Task TurnEcoModeOn_NoListeners_LockerManagerIsCalled()
        {
            await _manager.TurnEcoModeOn();

            _lockerManagerMock.Verify(x => x.SwitchEcoOn(), Times.Once);
        }

        [Test]
        public async Task TurnEcoModeOff_NoListeners_LockerManagerIsCalled()
        {
            await _manager.TurnEcoModeOff();

            _lockerManagerMock.Verify(x => x.SwitchEcoOff(), Times.Once);
        }

        [Test]
        public async Task TurnEcoModeOn_WithListeners_NotificationsAreSent()
        {
            var lockers = GetTestLockers(3, true);
            _lockerManagerMock.Setup(x => x.SwitchEcoOn()).Returns(Task.FromResult(lockers));
            var listenerMock = new Mock<ILockerStateChangeNotifier>();
            listenerMock.Setup(x => x.Notify(It.IsAny<IEnumerable<LockerState>>())).Verifiable();

            _manager.RegisterNotificationListener(listenerMock.Object);

            await _manager.TurnEcoModeOn();

            _lockerManagerMock.Verify(x => x.SwitchEcoOn(), Times.Once);
            listenerMock.Verify(x => x.Notify(lockers), Times.Once);
        }

        [Test]
        public async Task TurnEcoModeOff_WithListeners_NotificationsAreSent()
        {
            var lockers = GetTestLockers(3, false);
            _lockerManagerMock.Setup(x => x.SwitchEcoOff()).Returns(Task.FromResult(lockers));
            var listenerMock = new Mock<ILockerStateChangeNotifier>();
            listenerMock.Setup(x => x.Notify(It.IsAny<IEnumerable<LockerState>>())).Verifiable();

            _manager.RegisterNotificationListener(listenerMock.Object);

            await _manager.TurnEcoModeOff();

            _lockerManagerMock.Verify(x => x.SwitchEcoOff(), Times.Once);
            listenerMock.Verify(x => x.Notify(lockers), Times.Once);
        }

        [Test]
        public async Task TurnEcoModeOff_WithDisabledListeners_NotificationsAreSentOnlyForActiveOnes()
        {
            var lockers = GetTestLockers(3, false);
            _lockerManagerMock.Setup(x => x.SwitchEcoOff()).Returns(Task.FromResult(lockers));

            var listenerMock = new Mock<ILockerStateChangeNotifier>();
            listenerMock.Setup(x => x.Notify(It.IsAny<IEnumerable<LockerState>>())).Verifiable();

            var disabledListenerMock = new Mock<ILockerStateChangeNotifier>();
            disabledListenerMock.Setup(x => x.Notify(It.IsAny<IEnumerable<LockerState>>())).Verifiable();

            _manager.RegisterNotificationListener(listenerMock.Object);
            _manager.RegisterNotificationListener(disabledListenerMock.Object);
            _manager.DisableNotificationListener(disabledListenerMock.Object);

            await _manager.TurnEcoModeOff();

            _lockerManagerMock.Verify(x => x.SwitchEcoOff(), Times.Once);
            listenerMock.Verify(x => x.Notify(lockers), Times.Once);
            disabledListenerMock.Verify(x => x.Notify(lockers), Times.Never);

            _manager.EnableNotificationListener(disabledListenerMock.Object);

            await _manager.TurnEcoModeOff();

            _lockerManagerMock.Verify(x => x.SwitchEcoOff(), Times.Exactly(2));
            listenerMock.Verify(x => x.Notify(lockers), Times.Exactly(2));
            disabledListenerMock.Verify(x => x.Notify(lockers), Times.Once);
        }

        private IEnumerable<LockerState> GetTestLockers(int count, bool runsInEco)
        {
            var result = new List<LockerState>();

            for (int i = 0; i < count; i++)
            {
                result.Add(new LockerState()
                    {
                        LockerId = Guid.NewGuid(),
                        RunsInEco = runsInEco
                    }
                );
            }

            return result;
        }
    }
}