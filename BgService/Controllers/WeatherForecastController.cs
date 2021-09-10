using BgClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BgService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public IBgTaskQueue _queue { get; }
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public WeatherForecastController(IBgTaskQueue queue, IServiceScopeFactory serviceScopeFactory)
        {
            _queue = queue;
            _serviceScopeFactory = serviceScopeFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _queue.QueueBackgroundWorkItem(async token =>
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    int j = 1000;
                    for (int i = 0; i < j; i++)
                    {
                        Console.WriteLine(i);
                        await Task.Delay(TimeSpan.FromSeconds(1), token);
                    }
                    

                }
            });
            return Ok("In progress..");
        }
    }
}
