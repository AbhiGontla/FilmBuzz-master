using FilmBuzz.App_Start;
using FilmBuzz.Common.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FilmBuzz
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterInstance<IDispatcher>(DispatcherConfig.RegisterComponents());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}