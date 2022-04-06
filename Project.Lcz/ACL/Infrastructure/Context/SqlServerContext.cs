using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Models;
using Project.Lcz.Repository.Maping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Repository.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Reserva> Reserva { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:sql-project-lcz-prod.database.windows.net,1433;Database=sqldb-project-lcz-prod;User ID=lczadmin;Password=C0EWrm!rAA&b;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClienteMap());
            builder.ApplyConfiguration(new EnderecoMap());
            builder.ApplyConfiguration(new VeiculoMap());
            builder.ApplyConfiguration(new ReservaMap());
        }
    }
}
