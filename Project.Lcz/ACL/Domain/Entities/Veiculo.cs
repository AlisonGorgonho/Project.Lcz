using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ACL.Domain.Entities
{
    public class Veiculo
    {
        public int Id { get; set; }
        public int IdFabricante { get; set; }
        public string FabricanteNome { get; set; }
        public int IdModelo { get; set; }
        public string ModeloNome { get; set; }
        public string Placa { get; set; }
    }
}
