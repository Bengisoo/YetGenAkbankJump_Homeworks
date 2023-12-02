using Bogus;
using Microsoft.Extensions.Caching.Memory;
using YetGenAkbankJump.Domain.Entities;
using YetGenAkbankJump.Persistence.Contexts;

namespace YetGenAkbankJump.WebApi.Services
{
	public class FakeDataService
	{
		private readonly ApplicationDbContext _applicationDbContext;
		private readonly Random _random;
		
		public FakeDataService(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
			_random = new Random();
			
		}

		public async Task<int> GenerateStudentDataAsync(CancellationToken cancellationToken)
		{
			var fakeStudentRule = new Faker<Student>("tr")
				.RuleFor(S => S.Id, new Guid())
				.RuleFor(S => S.FirstName, f => f.Name.FirstName())
				.RuleFor(S => S.LastName, f => f.Name.LastName())
				.RuleFor(S => S.Country, f => f.Address.Country())
				.RuleFor(S => S.City, f => f.Address.City())
				.RuleFor(S => S.Company, f => f.Company.CompanyName())
				.RuleFor(S => S.Age, f => Convert.ToInt16(_random.Next(10, 59)))
				.RuleFor(S => S.RegistrationFee, f => _random.Next(0, 9999))
				.RuleFor(S => S.CreatedOn, f => DateTimeOffset.UtcNow)
				.RuleFor(S => S.CreatedByUserId, f => "fakestring");

			var students = fakeStudentRule.Generate(10000);

			foreach (var student in students)
				student.Id=Guid.NewGuid();
			
			await _applicationDbContext.Students.AddRangeAsync(students, cancellationToken);
			var recordCount= await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return recordCount;

		}
	}
}
