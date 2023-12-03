using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week11_1.API.Models;
using Week11_1.Domain.Entities;
using Week11_1.Persistence.Contexts;


namespace Week11_1.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		public Week11_1DbContext _context {  get; set; }

		public BooksController(Week11_1DbContext context)
		{
			_context = context;
		}

		[HttpPost("[action]")]
		public void SetDefaultBooksData()
		{
			List<Book> books = new()
			{
				new Book{ Id= Guid.Parse("1f418c11-49a6-4d1b-bb6f-7ce32c6c8b11"),CreatedOn= DateTime.UtcNow, CreatedByUserId="1", Title ="Little Prince", Author =" Antoine de Saint-Exupéry", PublicationYear =1943, PurchasePrice = 6.89m},
				new Book { Id = Guid.Parse("2f418c11-49a6-4d1b-bb6f-7ce32c6c8b22"), CreatedOn = DateTime.UtcNow, CreatedByUserId = "2", Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationYear = 1960, PurchasePrice = 10.99m },

				new Book { Id = Guid.Parse("3f418c11-49a6-4d1b-bb6f-7ce32c6c8b33"), CreatedOn = DateTime.UtcNow, CreatedByUserId = "3", Title = "1984", Author = "George Orwell", PublicationYear = 1949, PurchasePrice = 8.99m },

				new Book  { Id = Guid.Parse("1f418c11-49a6-4d1b-bb6f-7ce32c6c8b44"), CreatedOn = DateTime.UtcNow, CreatedByUserId = "4", Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicationYear = 1925, PurchasePrice = 12.50m },

				 new Book { Id = Guid.Parse("1f418c11-49a6-4d1b-bb6f-7ce32c6c8b55"), CreatedOn = DateTime.UtcNow, CreatedByUserId = "5", Title = "The Catcher in the Rye", Author = "J.D. Salinger", PublicationYear = 1951, PurchasePrice = 9.99m }


			};

			_context.Books.AddRange(books);
			
			_context.SaveChanges();
		}

		[HttpPost]
		public void AddBook(Book book)
		{
			//Book book = new()
			//{
			//	Title = title,
			//	Author = author,
			//	PurchasePrice = price,
			//	PublicationYear = year
			//};

			if (!ModelState.IsValid)
			{
				var messages = ModelState.ToList();
                Console.WriteLine(messages);
            }
			else
			{
				_context.Books.Add(book);
				_context.SaveChanges();
                Console.WriteLine("Book: " +book.Title+" is added");
            }

		}



		[HttpGet("[action]/{bookID:guid}")]
		public GetBookDataResponseModel GetBookData(Guid bookID)
		{
			var book = _context.Books.FirstOrDefault(x=>x.Id == bookID);
			var response = new GetBookDataResponseModel()
			{
				Title = book.Title,
				Author= book.Author,
				PublicationYear= book.PublicationYear
			};

			return response;
		}

	}
}
