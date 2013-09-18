using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EthioSpark.Entities
{
    public class CodeValue
    {
        public int CodeValueId { get; set; }
        public int CodeSetId { get; set; }
        public string DisplayName { get; set; }
        public string Meaning { get; set; }
        public CodeSet CodeSet { get; set; }
    }
}