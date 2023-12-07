// See https://aka.ms/new-console-template for more information
using _10thWeek_Homework01;

Console.WriteLine("Singleton");

ConfigurationService configurationService = ConfigurationService.GetInstance();

ConfigurationService.GetInstance().GetValue("");

var myConnectionString = configurationService.GetValue("ConnectionStrings:ExampleDb");

Console.WriteLine();
