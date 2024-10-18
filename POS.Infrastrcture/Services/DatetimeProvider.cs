using POS.Application.Common.Interfaces.Services;

namespace POS.Infrastrcture.Services;

public class DatetimeProvider : IDatetimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}