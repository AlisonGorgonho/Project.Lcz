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
    public class ReservaMap : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("reserva");

            builder.Property(t => t.Id).HasColumnName("id_reserva");
            builder.Property(t => t.IdCliente).HasColumnName("id_cliente");
            builder.Property(t => t.IdVeiculo).HasColumnName("id_veiculo");
            builder.Property(t => t.DataCriacao).HasColumnName("data_criacao");
            builder.Property(t => t.DataAtualizacao).HasColumnName("data_atualizacao");
            builder.Property(t => t.DataRetirada).HasColumnName("data_retirada");
            builder.Property(t => t.DataEsperadaDevolucao).HasColumnName("data_prevista_devolucao");
            builder.Property(t => t.DataDevolucao).HasColumnName("data_devolucao");
        }
    }
}
