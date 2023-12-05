using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week11_2.Domain.Dtos;
using Week11_2.Domain.Entities;
using Week11_2.Persistence.Contexts;

namespace Week11_2.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ApplicationDbContext _applicatonDbContext;

        public CategoriesController(ApplicationDbContext applicationDbContext)
        {
            _applicatonDbContext = applicationDbContext;
        }

		[HttpPost()]
		public async Task<IActionResult> AddAsync(CategoryAddDto categoryAddDto, CancellationToken cancellationToken)
		{
			if(categoryAddDto == null)		
				return BadRequest("Category's name cannot be null");

			var category = new Category()
			{
				Id = Guid.NewGuid(),
				Name = categoryAddDto.Name,
				CreatedByUserId = "zbd",
				CreatedOn = DateTimeOffset.Now,
				IsDeleted = false
			};

			await _applicatonDbContext.Categories.AddAsync(category, cancellationToken);
			await _applicatonDbContext.SaveChangesAsync(cancellationToken);
			

			return Ok(category);

		}

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			var category = await _applicatonDbContext
				.Categories
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

			return Ok(category);

		}

		[HttpGet]
		public async Task<IActionResult> GetByAll(CancellationToken cancellationToken)
		{
			var categories = await _applicatonDbContext
				.Categories
				.AsNoTracking()				
				.ToListAsync(cancellationToken);

			return Ok(categories);

		}
	}
}
