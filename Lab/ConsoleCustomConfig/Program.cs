using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace ConsoleCustomConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            // get config file from runtime args
            // or if none provided, request config
            // via console
            setConfigFileAtRuntime(args);

            // Rest of your console app
        }
        protected static void setConfigFileAtRuntime(string[] args)
        {
            string runtimeconfigfile;

            if (args.Length == 0)
            {
                Console.WriteLine("Please specify a config file:");
                Console.Write("> "); // prompt
                runtimeconfigfile = Console.ReadLine();
            }
            else
            {
                runtimeconfigfile = args[0];
            }

            // Specify config settings at runtime.
            System.Configuration.Configuration config
                = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.File = runtimeconfigfile;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}

