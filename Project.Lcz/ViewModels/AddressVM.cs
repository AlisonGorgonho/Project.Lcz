using Project.Lcz.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels
{
    public class AddressVM
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string StreetAddress { get; set; }
        public string Number { get; set; }
        public string AddressDetails { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public AddressType AddressType { get; set; }
        public int IdClient { get; set; }
    }
}
