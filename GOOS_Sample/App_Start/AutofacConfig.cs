using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using GOOS_Sample.Factories;
using GOOS_Sample.Interface;
using GOOS_Sample.Repositories;
using GOOS_Sample.Services;

namespace GOOS_Sample.App_Start
{
    public class AutofacConfig
    {
        private static IContainer container;

        public static IContainer Container
        {
            get
            {
                if (container == null)
                {
                    RegisterIoc();
                }

                return container;
            }

            set
            {
                container = value;
            }
        }

        public static IContainer RegisterIoc()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BudgetService>().As<IBudgetService>().PropertiesAutowired();

            builder.RegisterType<GOOSRepo>().As<IGOOSRepo>();
            //builder.RegisterInstance(RepositoryFactory.GOOSRepo).As<IGOOSRepo>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}