using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EthioSpark.Entities.Profile
{
    public class PrflAttrValue
    {
        public PrflAttrValue()
        {
            Users = new HashSet<User>();
        }

        public int PrflAttrValueId { get; set; }
        public string DisplayName { get; set; }
        public string InternalMeaning { get; set; }
        public int PrflAttrId { get; set; }

        public PrflAttr PrflAttr { get; set; }
        public ICollection<User> Users { get; set; }
    }
}