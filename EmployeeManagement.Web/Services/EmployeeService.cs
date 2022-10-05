using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Employee>($"api/employee/{id}");
            if(result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _httpClient.GetFromJsonAsync<Employee[]>("api/employee");
        }
        /// Create a service Folder
        /// Create a Service Interface IEmployeeService
        /// Create EmployeeService
        /// Add the dependency of httpClient with IEmployeeService and the baseUri in Program
        /// add new Nuget Package Microsoft.AspNetCore.Blazor.HttpClient
        /// return an Array GetJsonAsync using the httpclient injection
    }
}
