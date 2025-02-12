using united_movers_api.Models;

namespace united_movers_api.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllActiveEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(int employeeId);

        Task<int> InsertEmployeeAsync(Employee employee);

        Task<bool> UpdateEmployeeAsync(Employee employee);


    }
}
