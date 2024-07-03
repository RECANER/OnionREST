using Application.Interfaces;
using System;

namespace Shared.Services
{
    internal class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
