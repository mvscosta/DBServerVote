[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Vote.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Vote.App_Start.NinjectWebCommon), "Stop")]

namespace Vote.App_Start
{
    using System;
    using System.Reflection;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Vote.Core.Interfaces.DAO;
    using Vote.DAO.DataAccess;

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
                kernel.Load(Assembly.GetExecutingAssembly(),
                    Assembly.Load("Vote.DAO"),
                    Assembly.Load("Vote.Roles")
                    //Assembly.Load("Vote.CompositionRoot")
                );
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
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICategoriaDataAccess>().To<CategoriaDataAccess>();
            kernel.Bind<IFuncionarioDataAccess>().To<FuncionarioDataAccess>();
            kernel.Bind<IModalidadeDataAccess>().To<ModalidadeDataAccess>();
            kernel.Bind<IRestauranteDataAccess>().To<RestauranteDataAccess>();
            kernel.Bind<IVotoDataAccess>().To<VotoDataAccess>();
        }        
    }
}
