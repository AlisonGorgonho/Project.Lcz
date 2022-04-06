using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Repository.Maping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.Property(t => t.Id).HasColumnName("id_cliente");
            builder.Property(t => t.Nome).HasColumnName("nome");
            builder.Property(t => t.Cpf).HasColumnName("cpf");
            builder.Property(t => t.DataNascimento).HasColumnName("data_nascimento");
            builder.Property(t => t.CnhNumero).HasColumnName("numero_cnh ");
        }
    }
}
