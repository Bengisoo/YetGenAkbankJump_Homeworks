using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Week13.Application.Repositories.ProductRepositories;
using Week13.Domain.Entities;

namespace Week13.Application.Features.Queries.ProductQueries.Add
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;

        public AddProductHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price
            };
            _productWriteRepository.Add(product);
            _productWriteRepository.SaveChanges();

            return Task.FromResult(new AddProductResponse());
        }
    }
}
