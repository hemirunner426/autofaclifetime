using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacLifetime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder();

builder.ConfigureServices
    (services =>
    {
        services.AddHostedService<HostedService>();
        services.AddTransient<IRootService, RootService>();
        //services.AddTransient<IInheritedService, Child1Service>();
        //services.AddTransient<IInheritedService, Child2Service>();
    });

builder.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
{
    builder.RegisterType<Child1Service>().As<IInheritedService>();
    builder.RegisterType<Child2Service>().As<IInheritedService>();
}));

var host = await builder.StartAsync();

await host.WaitForShutdownAsync();


