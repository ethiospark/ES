using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EthioSpark.Entities
{
    public class CodeSet
    {
        public CodeSet()
        {
            CodeValues = new HashSet<CodeValue>();
        }

        public int CodeSetId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public ICollection<CodeValue> CodeValues { get; set; }
    }
}