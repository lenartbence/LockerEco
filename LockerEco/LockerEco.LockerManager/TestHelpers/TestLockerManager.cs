using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LockerEco.LockerManager.TestHelpers
{
    internal class TestLockerManager : ILockerSystemManager
    {
        private IList<Guid> _lockerIds;

        public TestLockerManager()
        {
            InitializeLockerIds(5);
        }

        public void InitializeLockerIds(int count)
        {
            _lockerIds = new List<Guid>();
            for (int i = 0; i < count; i++)
            {
                _lockerIds.Add(Guid.NewGuid());
            }
        }

        public Task<IEnumerable<LockerState>> SwitchEcoOn()
        {
            return Task.FromResult(GetLockerStates(true));
        }

        public Task<IEnumerable<LockerState>> SwitchEcoOff()
        {
            return Task.FromResult(GetLockerStates(false));
        }

        private IEnumerable<LockerState> GetLockerStates(bool isEcoOn)
        {
            return _lockerIds.Select(lockerId => new LockerState()
            {
                LockerId = lockerId,
                RunsInEco = isEcoOn
            });
        }
    }
}
