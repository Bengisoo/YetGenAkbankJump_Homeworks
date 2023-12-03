using Lecture7.API.Models;
using Lecture7.Domain.Entities;
using Lecture7.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lecture7.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly Week7_DbContext _context;

        public UsersController()
        {
			_context = new();   
        }

		[HttpGet]
        public List<User> GetAll()
		{
			return _context.Users.ToList();
		}

		[HttpPost]

		public IActionResult CreateUser([FromBody] CreateUserRequest createUserRequest)
		{
			User user = new()
			{
				FirstName = createUserRequest.FirstName,
				LastName = createUserRequest.LastName,
			};

			_context.Users.Add(user);

			//_context.SaveChanges();

			return Ok();
		}
	}
}
