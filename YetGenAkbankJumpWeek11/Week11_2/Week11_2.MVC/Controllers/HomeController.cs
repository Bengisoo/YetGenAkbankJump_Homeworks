using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Week11_2.MVC.Controllers
{

	public class HomeController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
