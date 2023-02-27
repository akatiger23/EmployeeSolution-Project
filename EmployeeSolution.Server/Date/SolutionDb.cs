using EmployeeSolution.Server;
using EmployeeSolution.Shared;
using EmployeeSolution.Shared.Modell;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EmployeeSolution.Server
{
    public class SolutionDb : DbContext
    {
        ConfigService _configService;
        public SolutionDb (ConfigService configService)
        {
            _configService = configService;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configService.ConnectionString);
        }

        public DbSet<Employee> Employees { get; set; }
        

        
    }
}
