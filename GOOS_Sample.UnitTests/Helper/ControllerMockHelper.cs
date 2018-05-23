using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;

namespace GOOS_Sample.UnitTests.Helper
{
    public static class ControllerMockHelper
    {
        public static T InvokeOnActionExecuting<T>(this System.Web.Mvc.Controller controller, Expression<Func<T>> exp) where T : ActionResult
        {
            var method = ((MethodCallExpression)exp.Body).Method;
            ControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor(controller.GetType());
            ActionDescriptor actionDescriptor = new ReflectedActionDescriptor(method, method.Name, controllerDescriptor);
            var actionContext = new ActionExecutingContext(controller.ControllerContext, actionDescriptor, new Dictionary<string, object>());
            MethodInfo onActionExecuting = controller.GetType().GetMethod("OnActionExecuting", BindingFlags.Instance | BindingFlags.NonPublic);
            onActionExecuting.Invoke(controller, new object[] { actionContext });

            return (T)actionContext.Result;
        }
    }
}