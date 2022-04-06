using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ACL.Domain.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdVeiculo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataEsperadaDevolucao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
