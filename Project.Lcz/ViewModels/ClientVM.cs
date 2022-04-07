using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels
{
    /// <summary>
    /// View Model to define ClientVM
    /// </summary>
    public class ClientVM
    {
        /// <summary>
        /// Id From ClientVM
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name From ClientVM
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Cpf From ClientVM
        /// </summary>
        public string Cpf { get; set; }
        /// <summary>
        /// BirthDate From ClientVM
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// CnhNumber From ClientVM
        /// </summary>
        public string CnhNumber { get; set; }
        /// <summary>
        /// Address From ClientVM
        /// </summary>
        public AddressVM Address { get; set; }
    }
}
