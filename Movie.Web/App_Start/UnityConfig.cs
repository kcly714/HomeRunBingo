using Movie.Data;
using Movie.Data.Providers;
using Movie.Services;
using Movie.Services.ContactUs;
using Movie.Services.Cryptography;
using Movie.Services.Interfaces;
using Movie.Web.Core.Services;
using System.Configuration;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace Movie.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            

            //this should be per request
            container.RegisterType<IAuthenticationService, OwinAuthenticationService>();

            container.RegisterType<ICryptographyService, Base64StringCryptographyService>(new ContainerControlledLifetimeManager());


            container.RegisterType<IDataProvider, SqlDataProvider>(
                new InjectionConstructor(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));

            container.RegisterType<IPrincipal>(new TransientLifetimeManager(),
                     new InjectionFactory(con => HttpContext.Current.User));
        // my controllers and services
            container.RegisterType<IContactUsService, ContactUsService>();
            container.RegisterType<IConfigService, ConfigService>();
            container.RegisterType<ISendGridService, SendGridService>();

            container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());

            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));


        }
    }
}
