using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Lcz.ACL.Domain.Entities;

namespace Project.Lcz.Repository.Maping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("endereco");

            builder.Property(t => t.Id).HasColumnName("id_endereco");
            builder.Property(t => t.Cep).HasColumnName("cep");
            builder.Property(t => t.Logradouro).HasColumnName("logradouro");
            builder.Property(t => t.Numero).HasColumnName("numero");
            builder.Property(t => t.Complemento).HasColumnName("complemento");
            builder.Property(t => t.Bairro).HasColumnName("bairro");
            builder.Property(t => t.Cidade).HasColumnName("cidade");
            builder.Property(t => t.Estado).HasColumnName("estado");
            builder.Property(t => t.TipoEndereco).HasColumnName("tipo_endereco");
            builder.Property(t => t.IdCliente).HasColumnName("id_cliente");
        }
    }
}
