using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace InventoryApp.Infrastructure
{
  /// <summary>
  /// Custom Action Filter Class
  /// </summary>
  public class CustomActionFilter : ActionFilterAttribute
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="actionExecutedContext"></param>
    
    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
      base.OnActionExecuted(actionExecutedContext);
      Notifier notifier = new Notifier();
      notifier.SendEmail("anjsahu19@gmail.com", "Notification Inventory App", string.Format("{1} -> {0} is executed", actionExecutedContext.ActionContext.ActionDescriptor.ActionName,actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="actionContext"></param>
    public override void OnActionExecuting(HttpActionContext actionContext)
    {
      base.OnActionExecuting(actionContext);
      Notifier notifier = new Notifier();
      notifier.SendEmail("anjsahu19@gmail.com", "Notification Inventory App", string.Format("{1} -> {0} is called", actionContext.ActionDescriptor.ActionName, actionContext.ControllerContext.ControllerDescriptor.ControllerName));
    }

  }
}
