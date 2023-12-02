using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10thWeekHomework
{
	public class ConfigurationService
	{
        public string GetValue(string key)
		{
			ConfigurationManager congfigurationManager = new();
			string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
			congfigurationManager.SetBasePath(path);
			congfigurationManager.AddJsonFile("Configurations.json");

			return congfigurationManager.GetSection(key).Value;


		}
    }
}
