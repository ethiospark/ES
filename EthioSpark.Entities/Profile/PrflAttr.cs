using System.Collections.Generic;
using System.Linq;

namespace EthioSpark.Entities.Profile
{
    public abstract class PrflAttr
    {
        public PrflAttr()
        {
            PrflAttrGrps = new HashSet<PrflAttrGrp>();
            PrflCtxs = new HashSet<PrflCtx>();
            PrflAttrValues = new HashSet<PrflAttrValue>();
        }

        public int PrflAttrId { get; set; }
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public ICollection<PrflAttrGrp> PrflAttrGrps { get; set; }
        public ICollection<PrflCtx> PrflCtxs { get; set; }
        public ICollection<PrflAttrValue> PrflAttrValues { get; set; }
    }
}