using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NToastNotify;
using Week11_2.Domain.Identity;
using Week11_2.MVC.ViewModels;

namespace Week11_2.MVC.Controllers
{
	public class AuthController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly IToastNotification _toastNotification;

        public AuthController(UserManager<User> userManager, IToastNotification toast, SignInManager<User> signInManager)
        {
			_userManager = userManager;
			_toastNotification = toast;
			_signInManager = signInManager;
        }

		
        public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			if (User.Identity.IsAuthenticated)
				return RedirectToAction("Index", controllerName: "Home");

			var registerViewModel = new AuthRegisterViewModel();
			return View(registerViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> RegisterAsync(AuthRegisterViewModel registerViewModel)
		{
			if(!ModelState.IsValid)
				return View(registerViewModel);

			var userId = Guid.NewGuid();

            var user = new User()
            {
                Id = userId,
                Email = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                SurName = registerViewModel.SurName,
                Gender = registerViewModel.Gender,
                BirthDate = registerViewModel.BirthDate.Value.ToUniversalTime(),
                UserName = registerViewModel.UserName,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = userId.ToString()
            };
			var identityResult = await _userManager.CreateAsync(user,registerViewModel.Password);

			if (!identityResult.Succeeded)
				throw new Exception("Patladık :)");

			_toastNotification.AddSuccessToastMessage("You've successfully registered to the application");

			return RedirectToAction(nameof(Login));
		}
		[HttpGet]
		public IActionResult Login()
		{
			if (User.Identity.IsAuthenticated)
				return RedirectToAction("Index", controllerName: "Home");

			var loginViewModel = new AuthLoginViewModel();
			return View(loginViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> LoginAsync(AuthLoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid)
				return View(loginViewModel);

			var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
			if (user is null)
			{
				_toastNotification.AddErrorToastMessage("Your email or password is wrong");
				return View(loginViewModel);
			}

			var loginResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true, false);

			if (!loginResult.Succeeded)
			{
				_toastNotification.AddErrorToastMessage("Your email or password is incorrect.");

				return View(loginViewModel);
			}


			_toastNotification.AddSuccessToastMessage($"Welcome {user.UserName}");
			return RedirectToAction("Index", controllerName:"Student");

		}
	}

	
}
