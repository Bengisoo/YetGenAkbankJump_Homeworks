using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week13.Application.Features.Queries.ProductQueries.Add;
using Week13.Application.Repositories.ProductRepositories;
using Week13.Domain.Entities;
using Week13.Persistence.Contexts;
using Week13.Persistence.Repositories.ProductRepositories;

namespace Week13.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       

        private readonly IProductReadRepository _productReadRepository;
        private readonly IMediator _mediator;

        public ProductsController(IProductReadRepository productReadRepository, IMediator mediator)
        {
            _productReadRepository = productReadRepository;
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public List<Product> GetAll()
        {
            return _productReadRepository.GetAll();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(AddProductRequest addProductRequest)
        {
            var response = await _mediator.Send(addProductRequest);
            return Ok(response);
        }


    }
}
