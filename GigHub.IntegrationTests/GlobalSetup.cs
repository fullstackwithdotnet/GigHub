using GigHub.Core.Models;
using GigHub.Persistence;
using NUnit.Framework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GigHub.IntegrationTests
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [SetUp]
        public void SetUp()
        {
            MigrateDbToLatestVersion();
            Seed();
        }

        private static void MigrateDbToLatestVersion()
        {
            var configuration = new GigHub.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        public void Seed()
        {
            var context = new ApplicationDbContext();

            if (context.Users.Any())
            {
                return;

            }

            context.Users.Add(new ApplicationUser
            { UserName = "user1@domain.com", Name = "User1", Email = "-", PasswordHash = "-" });
            context.Users.Add(new ApplicationUser
            { UserName = "user2@domain.com", Name = "User2", Email = "-", PasswordHash = "-" });

            context.SaveChanges();
        }
    }
}
