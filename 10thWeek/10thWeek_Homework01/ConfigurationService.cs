using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10thWeek_Homework01
{
	public class ConfigurationService
	{
		private static ConfigurationService instance;
		public static ConfigurationService GetInstance()
		{
			if(instance is null)
				instance = new ConfigurationService();
			return instance;
		}
		public string GetValue(string key)
		{
			ConfigurationManager congfigurationManager = new();
			string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
			//string path= Directory.GetCurrentDirectory().ToString();
			congfigurationManager.SetBasePath(path);
			congfigurationManager.AddJsonFile("Configuration.json");

			return congfigurationManager.GetSection(key).Value;


		}

        ConfigurationService()
        {
            Console.WriteLine("Instance is created");
        }
    }
}

