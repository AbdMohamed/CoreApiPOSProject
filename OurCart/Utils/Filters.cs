using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OurCart.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurCart.Utils
{
    public class ModelStateValidation : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                OperationResponse<dynamic> or = new OperationResponse<dynamic>();
                or.HasErrors = true; 
                or.Data= string.Format("Check {0} Model  Validation", context.ActionDescriptor.Parameters.FirstOrDefault().ParameterType);
                context.Result = new BadRequestObjectResult(or);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}

