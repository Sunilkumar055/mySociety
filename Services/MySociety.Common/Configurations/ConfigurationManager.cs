using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySociety.Common.Configurations
{
    public class ConfigurationManager
    {
        private readonly IConfiguration configuration;

        public ConfigurationManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string ConnectionString => configuration["DefaultConnection"]; //configuration.GetConnectionString("DefaultConnection");
    }
}

