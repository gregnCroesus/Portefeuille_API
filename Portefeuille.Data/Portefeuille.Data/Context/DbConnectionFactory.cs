using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portefeuille.Data.Context
{
    public class DbConnectionFactory : ICroesusDbContextFactory
    {
        private readonly IConfiguration _config;
        public DbConnectionFactory(IConfiguration config)
        {
            this._config = config;
        }
        public CroesusDbContext Create()
        {
            return new CroesusDbContext(this._config.GetConnectionString("CroesusDatabase"));
        }
    }
}
