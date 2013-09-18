//using System.Collections.Generic;

//namespace EthioSpark.BuisnessLogic.Utils
//{
//    public class CodeValueHelper
//    {
//        public static Dictionary<int, CodeValue> CodeValues { get; private set; }
//        public static Dictionary<int, CodeSet> CodeSets { get; private set; }

//        public static void LoadCodeValues()
//        {
//            using (var context = new EthiosparkEntities())
//            {
//                CodeSets = new Dictionary<int, CodeSet>();
//                CodeValues = new Dictionary<int, CodeValue>();

//                var lookupList = from cv in context.CodeValues 
//                                 join cs in context.CodeSets on cv.CodeSetId equals cs.Id 
//                                 select new {codeSet = cs, codeValue = cv};

//                foreach (var l in lookupList)
//                {
//                    if (l != null)
//                    {
//                        if (!CodeValues.ContainsKey(l.codeValue.Id))
//                        {
//                            CodeValues.Add(l.codeValue.Id, l.codeValue);
//                            context.Detach(l.codeValue);
//                        }

//                        if (l.codeSet != null && !CodeSets.ContainsKey(l.codeSet.Id))
//                        {
//                            CodeSets.Add(l.codeSet.Id, l.codeSet);
//                            context.Detach(l.codeSet);
//                        }
//                    }
//                }
//            }
//        }

//        static CodeValueHelper()
//        {
//            LoadCodeValues();
//        }
//    }
//}
