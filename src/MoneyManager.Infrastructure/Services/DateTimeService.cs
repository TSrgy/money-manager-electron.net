using MoneyManager.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
