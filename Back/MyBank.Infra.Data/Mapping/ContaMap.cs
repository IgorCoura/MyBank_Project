using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBank.Domain.Entities;

namespace MyBank.Infra.Data.Mapping
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Contas");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Agencia)
                .IsRequired()
                .HasColumnName("Agencia");
            builder.Property(prop => prop.NumConta)
                .IsRequired()
                .HasColumnName("NumeroConta");
            builder.Property(prop => prop.Saldo)
                .IsRequired()
                .HasColumnName("Saldo");
            builder.HasOne(prop => prop.Cliente).WithMany(prop => prop.Conta).IsRequired();
        }
    }
}
