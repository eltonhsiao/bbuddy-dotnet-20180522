//using System.Collections.Specialized;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Routing;
//using NSubstitute;

//namespace GOOS_Sample.UnitTests.Helper
//{
//    public static class ControllerTestHelper
//    {
//        public static T MockContext<T>(T controller) where T : Controller
//        {
//            var httpRequestBase = Substitute.For<HttpRequestBase>();
//            httpRequestBase.Headers.Returns(new NameValueCollection());
//            httpRequestBase.QueryString.Returns(new NameValueCollection());

//            var httpContextBase = Substitute.For<HttpContextBase>();
//            httpContextBase.Request.Returns(httpRequestBase);
//            httpContextBase.Session.Returns(Substitute.For<HttpSessionStateBase>());

//            controller.ControllerContext = new ControllerContext(httpContextBase, new RouteData(), controller);
//            return controller;
//        }
//    }
//}