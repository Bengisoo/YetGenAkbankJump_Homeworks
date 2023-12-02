using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week10th.Application.Services;
using Week10th.Infrastructure.Services;

namespace Week10th_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
        private readonly IConfigurationService _configurationService;

		public CustomersController(IConfigurationService configurationService)
		{
			_configurationService = configurationService;
		}



        [HttpGet]
        public void Get(string name)
        {
			_configurationService.GetValue(name);
            
        }
    }
}
