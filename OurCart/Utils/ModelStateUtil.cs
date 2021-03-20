using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OurCart.Utils
{
    public static class ModelStateUtil
    {
        public static string GETModelStateErrorMSG(ModelStateDictionary modelState)
        {
            string ErrorMSG = "";
            foreach (var item in modelState.Values)
            {
                foreach (ModelError error in item.Errors)
                {
                    ErrorMSG += error.ErrorMessage + "\n";
                }
            }
            return ErrorMSG;
        }

    }
}
