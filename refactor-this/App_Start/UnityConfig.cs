using refactor_this.IService;
using refactor_this.Services;
using System.Web.Http;
using System.Web.Mvc;
using Unity; 
using Unity.WebApi;

namespace refactor_this
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer(); 
            //Register the Repository in the Unity Container
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<ITransactionService, TransactionService>(); 
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}