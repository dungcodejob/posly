using Posly.Application.Common.Interfaces.Services;

namespace Posly.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
}

