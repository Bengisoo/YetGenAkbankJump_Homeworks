using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Week11_2.MVC.Controllers
{
	[Authorize]
	public class StudentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
