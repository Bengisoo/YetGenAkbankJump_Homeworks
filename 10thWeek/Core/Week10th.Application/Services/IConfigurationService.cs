using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10th.Application.Services
{
	public interface IConfigurationService
	{
		
		string GetValue(string key);

	}
}
