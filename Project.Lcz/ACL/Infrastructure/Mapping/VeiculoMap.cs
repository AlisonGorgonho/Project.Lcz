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
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("veiculo");

            builder.Property(t => t.Id).HasColumnName("id_veiculo");
            builder.Property(t => t.IdFabricante).HasColumnName("id_fabricante");
            builder.Property(t => t.FabricanteNome).HasColumnName("nome_fabricante");
            builder.Property(t => t.IdModelo).HasColumnName("id_modelo");
            builder.Property(t => t.ModeloNome).HasColumnName("nome_modelo");
            builder.Property(t => t.Placa).HasColumnName("placa");
        }
    }
}
