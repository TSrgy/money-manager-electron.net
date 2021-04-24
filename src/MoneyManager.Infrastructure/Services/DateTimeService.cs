using System;
using System.Collections.Generic;
using System.Text;
using MoneyManager.Application.Common.Interfaces;

namespace MoneyManager.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
