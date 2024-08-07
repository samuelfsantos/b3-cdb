using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using B3.Cdb.Domain.Validators;
using B3.Cdb.Application.Interfaces;
using B3.Cdb.Application.Services;
using B3.Cdb.Domain.Services;
using B3.Cdb.Domain.Notifications;
using SimpleInjector.Lifestyles;

namespace B3.Cdb.IoC
{
    public static class IocConfig
    {
        public static void RegisterDependencies()
        {
            // Configuração do Simple Injector
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Registrar serviços e dependências
            container.Register<IInvestimentoValidator, InvestimentoValidator>(Lifestyle.Scoped);
            container.Register<ICalculadoraDeInvestimento, CalculadoraDeInvestimento>(Lifestyle.Scoped);
            container.Register<IInvestimentoApplication, InvestimentoApplication>(Lifestyle.Scoped);
            container.Register<INotifier, Notifier>(Lifestyle.Scoped);

            // Registrar controladores WebApi
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
