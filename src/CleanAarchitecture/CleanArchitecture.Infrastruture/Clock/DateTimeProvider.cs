

using CleanArchitecture.Application.Abstrations.Clock;

namespace CleanArchitecture.Infrastruture.Clock
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime currentTime => DateTime.UtcNow;
    }
}