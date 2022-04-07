using Project.Lcz.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels
{
    /// <summary>
    /// View Model to define AddressVM
    /// </summary>
    public class AddressVM
    {
        /// <summary>
        /// Id from AddressVM
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Cep from AddressVM
        /// </summary>
        public string Cep { get; set; }
        /// <summary>
        /// StreetAddress from AddressVM
        /// </summary>
        public string StreetAddress { get; set; }
        /// <summary>
        /// Number from AddressVM
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// AddressDetails from AddressVM
        /// </summary>
        public string AddressDetails { get; set; }
        /// <summary>
        /// District from AddressVM
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// City from AddressVM
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// State from AddressVM
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// AddressType from AddressVM [HOME -> 0, WORK -> 1, OTHER -> 2]
        /// </summary>
        public AddressType AddressType { get; set; }
        /// <summary>
        /// IdClient from AddressVM
        /// </summary>
        public int IdClient { get; set; }
    }
}
