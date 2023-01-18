namespace CetusFood.Common.Abstractions.Extensions;

public interface IClock
{
    DateTime CurrentDateTime();
    DateTime DayBackFromNow();
    DateTimeOffset CurrentDateTimeOffset();
    DateTimeOffset CurrentLocalDateTimeOffset();
}

public class UtcClock : IClock
{
    public DateTime CurrentDateTime() => DateTime.UtcNow;
    public DateTime DayBackFromNow() => DateTime.UtcNow.AddDays(-1);
    public DateTimeOffset CurrentDateTimeOffset() => DateTimeOffset.UtcNow;
    public DateTimeOffset CurrentLocalDateTimeOffset()=> DateTimeOffset.Now;
}