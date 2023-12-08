using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week13.Application.Repositories.CustomerRepositories;
using Week13.Domain.Entities;
using Week13.Persistence.Repositories.CustomerRepositories;

namespace Week13.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerReadRepository _customerReadRepository;

        public CustomersController(CustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        [HttpGet]
        public List<Customer> GetAllCustomers()
        {
            return _customerReadRepository.GetAll();
        }
    }
}
