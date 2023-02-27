using EmployeeSolution;
using EmployeeSolution.Shared.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSolution.Shared
{
    public class AppService
    {
        HttpClient http;
        public AppService(HttpClient _http)
        {
            http = _http;

        }
        public Employee? Employee;
        public async Task<SaveEmployeeRespons> SaveEmployee(Employee emp)
        {
            SaveEmployeeRespons msg = null;
            var resp = await http.PostAsJsonAsync("https://localhost:7064/employee",emp);
            if (resp.IsSuccessStatusCode)
            {
                msg = await resp.Content.ReadFromJsonAsync<SaveEmployeeRespons>();
                if(msg == null)
                {
                    msg = new SaveEmployeeRespons
                    {
                        Returncod = -1,
                        ReturnMessage = "Json data is null"
                        

                    };
                }
            }
            else
            {
                msg = new SaveEmployeeRespons
                {
                    Returncod = -1,
                    ReturnMessage = "Http Respons Status was not successful."


                };

            }
            return msg;
        }
    }
}
