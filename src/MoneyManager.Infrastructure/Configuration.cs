using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Configuration;

namespace MoneyManager.Infrastructure
{
    public class Configuration
    {
        public Configuration(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
            var validator = new Validator();
            validator.ValidateAndThrow(this);
        }

        public string ConnectionString { get; }

        public class Validator : AbstractValidator<Configuration>
        {
            public Validator()
            {
                RuleFor(c => c.ConnectionString).NotEmpty();
            }
        }
    }
}
