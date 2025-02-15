using united_movers_api.Models;

namespace united_movers_api.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<LoginResponse> ValidateEmployeeLogin(LoginRequest loginRequest);
        Task<CreateEmployeeResponse> ValidateAndCreateEmployee(Employee employee);

        Task<bool> Logout(int employeeID  );
        Task<IEnumerable<Employee>> GetActiveEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(int employeeId);

        Task<int> InsertEmployeeAsync(Employee employee);

        Task<bool> UpdateEmployeeAsync(Employee employee);

    }
}
