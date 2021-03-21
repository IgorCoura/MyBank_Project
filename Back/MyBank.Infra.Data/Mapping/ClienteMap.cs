using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBank.Domain.Entities;

namespace MyBank.Infra.Data
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .IsRequired()
                .HasColumnName("Nome");

            builder.Property(prop => prop.CPF)
                .IsRequired()
                .HasColumnName("CPF");

            builder.Property(prop => prop.DataNascimento)
                .IsRequired()
                .HasColumnName("DataNascimento");

            builder.Property(prop => prop.Senha)
                .IsRequired()
                .HasColumnName("Senha");

            builder.Property(prop => prop.Token)
                .HasColumnName("Token");
            builder.Property(prop => prop.ExpirationToken)
                .HasColumnName("ExpirationToken");
            builder.HasMany(prop => prop.Conta).WithOne(prop => prop.Cliente);
        }
    }
}
