using Week10th.Application.Services;

namespace Week10th.Domain
{
	
	public class MyExampleClass
	{
		private readonly IConfigurationService _configurationService;

        public MyExampleClass(IConfigurationService _configService)
        {
            _configurationService = _configService;
        }

		


	}
}