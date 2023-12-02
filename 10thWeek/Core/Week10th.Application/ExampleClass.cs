using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10th.Application.Services;

namespace Week10th.Application
{
	public class ExampleClass
	{
		private readonly IConfigurationService _configurationService;

        public ExampleClass(IConfigurationService _configService)
        {
            _configurationService = _configService;
			var myConnectionString= _configurationService.GetValue("Seq:ServerURL");
            Console.WriteLine(myConnectionString);
        }

		
    }
}
