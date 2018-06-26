[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Welo.WebApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Welo.WebApp.App_Start.NinjectWebCommon), "Stop")]


namespace Welo.WebApp.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Welo.Application.AppServices;
    using Welo.Application.Interfaces;
    using Welo.Data;
    using Welo.Domain.Interfaces.Repositories;
    using Welo.Domain.Interfaces.Services;
    using Welo.Domain.Services;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IFilmeRepository>().To<FilmeRepository>();
            kernel.Bind<IFilmeService>().To<FilmeService>();
            kernel.Bind<IFilmeAppService>().To<FilmeAppService>();
        }
    }
}