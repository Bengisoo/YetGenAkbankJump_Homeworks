using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week10th.Application.Services;
using Week10th.Infrastructure.Services;


namespace Week10th_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly IConfigurationService _configuration;

		public ValuesController(IConfigurationService configuration)
		{
			_configuration = configuration;
		}



		[HttpGet]
		public void Get(string name)
		{
			_configuration.GetValue(name);
		}
	}
}
