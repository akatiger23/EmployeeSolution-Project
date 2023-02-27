using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSolution.Shared
{
    public class ConfigService
    {
        private IConfiguration _config;
        public ConfigService(IConfiguration config)
        {
            _config=config;
        }
        public string ConnectionString => _config["ConnectionStrings:SolutionDb"]; //Path from JSON datei 

    }
}
