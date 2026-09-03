using Autofac;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Services;
using System.ComponentModel.DataAnnotations;


namespace DependencyInjectionExample.Controllers
{
    public class HomeController : Controller
    {
        //readonly CitiesService _citiesService;
        readonly ICitiesService _citiesService1;
        readonly ICitiesService _citiesService2;
        readonly ICitiesService _citiesService3;

        //readonly IServiceScopeFactory _serviceScopeFactory;
        readonly ILifetimeScope _lifeTimeScope;

        //constructor
        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, ILifetimeScope lifeTimeScope)//, IServiceScopeFactory serviceScopeFactory)
        {
            //create object of CitiesService class
            //_citiesService = new CitiesService();
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            //_serviceScopeFactory = serviceScopeFactory;
            _lifeTimeScope = lifeTimeScope;
        }

        [Route("/")]
        public IActionResult Index()
        {
            var cities = _citiesService1.GetCities();

            ViewBag.InstanceId_CityService_1 = _citiesService1.ServiceInstanceId;
            ViewBag.InstanceId_CityService_2 = _citiesService2.ServiceInstanceId;
            ViewBag.InstanceId_CityService_3 = _citiesService3.ServiceInstanceId;

            //using (var scope = _serviceScopeFactory.CreateScope())
            using (var scope = _lifeTimeScope.BeginLifetimeScope())
            {
                //Inject CitiesService
                //ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>();
                ICitiesService citiesService = scope.Resolve<ICitiesService>();
                // DB Work

                ViewBag.InstanceId_CityService_InScope = citiesService.ServiceInstanceId;
            } // end of scope; it calls CitiesService.Dispose()

            return View(cities);
        }

        //[Route("/")]
        //public IActionResult Index([FromServices] ICitiesService _citiesService)
        //{
        //    var cities = _citiesService.GetCities();
        //    return View(cities);
        //}
    }
}
