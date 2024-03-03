using FinancialManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;

namespace FinancialManagementApp.Infrastructure.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletHistory> WalletHistories { get; set; }


        private readonly IConfiguration _configuration;
        public DataBaseContext()
        {
            _configuration = new ConfigurationBuilder()
                .AddUserSecrets("0146aae4-ce2f-40b1-9098-adcbc859cda2")
                .Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("defaultConnectionString"));
        }
    }
}
