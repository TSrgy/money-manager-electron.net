﻿using FluentAssertions;
using MoneyManager.Application.Accounts.Queries;
using MoneyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.IntegrationTests.Accounts.Queries
{
    [Collection("Database collection")]
    public class GetAccountsQueryTests : TestBase
    {
        public GetAccountsQueryTests(DatabaseFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task ShouldReturnAllAccounts()
        {
            var query = new GetAccountsQuery();
            var name1 = "test1";
            var name2 = "test2";

            await Fixture.AddAsync(new Account()
            {
                Name = name1
            });

            await Fixture.AddAsync(new Account()
            {
                Name = name2
            });

            var accountsVm = await Fixture.SendAsync(query);

            accountsVm.Accounts.Should().HaveCount(2);
            accountsVm.Accounts[0].Name.Should().Be(name1);
            accountsVm.Accounts[1].Name.Should().Be(name2);
        }
    }
}
