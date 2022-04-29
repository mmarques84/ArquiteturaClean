using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
    
}
