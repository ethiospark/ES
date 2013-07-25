using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EthioSpark.Helpers
{
    internal class ErrorHandler
    {
        public static JsonResult GetModelStateErrors(ModelStateDictionary modelState)
        {
            IEnumerable<ModelError> modelStateErrors = modelState.Keys.SelectMany(key => modelState[key].Errors).Where(err => !string.IsNullOrEmpty(err.ErrorMessage));
            return new JsonResult
                   {
                       Data = new
                              {
                                  userErrorMessage = true,
                                  errors = modelStateErrors
                              }
                   };
        }
    }
}