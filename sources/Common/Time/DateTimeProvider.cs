namespace MadWorldNL.Common.Time;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow() => DateTime.UtcNow;
}