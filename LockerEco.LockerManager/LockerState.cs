using System;

namespace LockerEco.LockerManager
{
    public class LockerState
    {
        public Guid LockerId { get; init; }

        public bool RunsInEco { get; init; }
    }
}