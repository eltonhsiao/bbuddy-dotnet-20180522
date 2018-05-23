using Autofac;
using Autofac.Integration.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOOS_Sample.UnitTests.Controller
{
    public class ControllerBaseTest<TController>
    {
        [SetUp]
        public void SetUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            var controller = builder.Build();

            Controller = controller.Resolve<TController>();
        }

        protected TController Controller { get; private set; }
    }
}