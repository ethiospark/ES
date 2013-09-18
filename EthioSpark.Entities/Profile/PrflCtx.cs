using System.Collections.Generic;

namespace EthioSpark.Entities.Profile
{
    public class PrflCtx
    {
        public PrflCtx()
        {
            PrflAttrGrps = new HashSet<PrflAttrGrp>();
            PrflAttrs = new HashSet<PrflAttr>();
        }

        public int PrflCtxId { get; set; }
        public string Name { get; set; }

        public ICollection<PrflAttrGrp> PrflAttrGrps { get; set; }
        public ICollection<PrflAttr> PrflAttrs { get; set; }
    }
}