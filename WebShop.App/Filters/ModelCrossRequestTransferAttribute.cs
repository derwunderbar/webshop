using System.Web.Mvc;
using WebShop.Utilities;

namespace WebShop.Filters
{
    public class ModelCrossRequestTransferAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var modelCrossRequestProvider = new ModelCrossRequestProvider(filterContext.Controller.TempData);
            modelCrossRequestProvider.Set(modelCrossRequestProvider.Get());
            base.OnActionExecuted(filterContext);
        }
    }
}