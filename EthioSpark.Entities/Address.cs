using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EthioSpark.Entities
{
    public class Address
    {
        public Address()
        {
            Users = new HashSet<User>();
        }
        public int AddressId { get; set; }
        public string ZipCode { get; set; }
        public int CityCd { get; set; }
        public int CountryCd { get; set; }
        [ForeignKey("CityCd")]
        public CodeValue CityCodeValue { get; set; }
        [ForeignKey("CountryCd")]
        public CodeValue CountryCodeValue { get; set; }
        public ICollection<User> Users { get; set; }
    }
}