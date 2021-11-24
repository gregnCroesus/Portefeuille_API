using EntityFrameworkCore.Ase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portefeuille.Data.Entities;
namespace Portefeuille.Data.Context
{
    public class CroesusDbContext : DbContext
    {
        private readonly IConfiguration _config;

        private readonly string _connString;
        public CroesusDbContext(string connString)
        {
            _connString = connString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseAse(_connString);
        }

        public DbSet<ClientEntity> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
