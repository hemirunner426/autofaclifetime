using Autofac;
using Microsoft.Extensions.Hosting;
using System.Runtime.Loader;


namespace AutofacLifetime
{
    public class HostedService : IHostedService
    {
        private readonly ILifetimeScope rootScope;
        private readonly AssemblyLoadContext childContext = new("test", true);

        private ILifetimeScope? childScope;

        public HostedService(ILifetimeScope rootScope)
        {
            this.rootScope = rootScope;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            childScope = rootScope.BeginLoadContextLifetimeScope(childContext, builder => {
                builder.RegisterType<ChildService>().As<IChildService>();
            });
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1000);  //some work to do before we shut down.
            if(childScope is not null)
                await childScope.DisposeAsync(); //The generic base class InheritedService<T> causes a SOE here.
        }
    }
}
