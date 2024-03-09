using Core.Date;

namespace Infrastructure.Date;

public class DateService : IDateService
{
    public DateTime CurrentDateTime() => DateTime.Now.ToUniversalTime(); 
}