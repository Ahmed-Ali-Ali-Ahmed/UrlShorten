using ClassLibrary1Shortnr.Web.Business;
using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Shortnr.web
{
    public static class UnityConfig
    {



        private static Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUrlManager, UrlManager>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}