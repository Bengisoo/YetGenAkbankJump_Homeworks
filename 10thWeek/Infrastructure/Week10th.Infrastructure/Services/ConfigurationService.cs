using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10th.Application.Services;

namespace Week10th.Infrastructure.Services
{
	public class ConfigurationService :IConfigurationService
	{
		//private static ConfigurationService instance;
		//public static ConfigurationService GetInstance()
		//{
		//	if (instance is null)
		//		instance = new ConfigurationService();
		//	return instance;
		//}
		public string GetValue(string key)
		{
			ConfigurationManager congfigurationManager = new();
			string path = Directory.GetCurrentDirectory();
			//string path= Directory.GetCurrentDirectory().ToString();
			congfigurationManager.SetBasePath(path);
			congfigurationManager.AddJsonFile("appsettings.json");

			return congfigurationManager.GetSection(key).Value;


		}
		
		public ConfigurationService()
		{
			Console.WriteLine("Instance is created");
		}
	}
}
