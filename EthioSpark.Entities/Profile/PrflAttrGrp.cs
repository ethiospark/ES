using System.Collections.Generic;

namespace EthioSpark.Entities.Profile
{
    public class PrflAttrGrp
    {
        public PrflAttrGrp()
        {
            PrflAttrs = new HashSet<PrflAttr>();
            PrflCtxs = new HashSet<PrflCtx>();
        }

        public int PrflAttrGrpId { get; set; }
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public ICollection<PrflAttr> PrflAttrs { get; set; }
        public ICollection<PrflCtx> PrflCtxs { get; set; }
    }
}