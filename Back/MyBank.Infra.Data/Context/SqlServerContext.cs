using Microsoft.EntityFrameworkCore;
using MyBank.Domain.Entities;
using MyBank.Infra.Data.Mapping;

namespace MyBank.Infra.Data.Context
{
    public class SqlServerContext : DbContext   
    {
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Conta> Contas { get; set; }
        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Conta>(new ContaMap().Configure);
        }
    }
}
