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
	public class ProductsController : ControllerBase
	{
		private readonly ApplicationDbContext _applicationDbContext;

		public ProductsController(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			var product = await _applicationDbContext
				.Products
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

			return Ok(product);


		}
		[HttpGet]
		public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
		{
			var products = await _applicationDbContext
				.Products
				.Include(x => x.Category)
				.AsNoTracking()
				.Select(x => new ProductDto()
				{
					Id = x.Id,
					CreatedOn = x.CreatedOn,
					Name = x.Name,
					//Categories = x.ProductCategories.Select(x => new ProductGetAllCategoryDto()
					//{
					//	Id = x.Category.Id,
					//	Name = x.Category.Name,
					//}).ToList()
				}).ToListAsync(cancellationToken);

			return Ok(products);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(ProductAddDto productAddDto, CancellationToken cancellationToken)
		{
			if (productAddDto is null || string.IsNullOrEmpty(productAddDto.Name) ||
				productAddDto.CategoryId == Guid.Empty)
				return BadRequest();

			var product = new Product()
			{
				Id = Guid.NewGuid(),
				Name = productAddDto.Name,
				CreatedOn = DateTime.UtcNow,
				CreatedByUserId = "zbd",
				IsDeleted = false,

			};

			await _applicationDbContext.Products.AddAsync(product, cancellationToken);
			await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return Ok(product);
		}
	}
}
