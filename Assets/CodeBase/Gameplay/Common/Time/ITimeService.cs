using System;

namespace CodeBase.Gameplay.Common.Time
{
    public interface ITimeService
    {
        float DeltaTime { get; }
        float DeltaFixedTime { get; }
        DateTime UtcNow { get; }
        void StopTime();
        void StartTime();
    }
}