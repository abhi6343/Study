using Autofac;
using Autofac.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllersWithViews();

//builder.Services.Add(new ServiceDescriptor(
//    typeof(ICitiesService),
//    typeof(CitiesService),
//    ServiceLifetime.Scoped
//));

//builder.Services.AddTransient<ICitiesService, CitiesService>();
//builder.Services.AddScoped<ICitiesService, CitiesService>();
//builder.Services.AddSingleton<ICitiesService, CitiesService>();

//AddTransient
//builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => { containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency(); });
//AddScoped
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => { containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope(); });
//AddSingleton
//builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => { containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance(); });


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
