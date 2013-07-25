using System.Collections.Generic;
using System.Linq;
using EthioSpark.DataAccess.Model;
using EthioSpark.Entities;

namespace EthioSpark.BuisnessLogic.Utils
{
    public class CodeValueHelper
    {
        public static Dictionary<int, CodeValue> CodeValues { get; private set; }
        public static Dictionary<int, CodeSet> CodeSets { get; private set; }

        public static void LoadCodeValues()
        {
            using (var context = new ModelContext())
            {
                CodeSets = new Dictionary<int, CodeSet>();
                CodeValues = new Dictionary<int, CodeValue>();
                foreach (var cv in context.CodeValues)
                {
                    if (cv != null)
                    {
                        if (!CodeValues.ContainsKey(cv.Id))
                            CodeValues.Add(cv.Id, cv);
                        if (cv.CodeSet != null && !CodeSets.ContainsKey(cv.CodeSet.Id))
                            CodeSets.Add(cv.CodeSet.Id, cv.CodeSet);
                    }
                }
            }
        }

        static CodeValueHelper()
        {
            LoadCodeValues();
        }
    }
}
