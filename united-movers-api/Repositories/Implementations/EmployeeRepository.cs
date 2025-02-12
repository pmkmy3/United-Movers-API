using Microsoft.Data.SqlClient;
using System.Data;
using united_movers_api.Models;
using united_movers_api.Repositories.Interfaces;

namespace united_movers_api.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _dbConnection;

        public EmployeeRepository(IDbConnection dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Employee>> GetAllActiveEmployeesAsync()
        {
            try
            {
                using (var command = _dbConnection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetEmployeeByID]";
                    IDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@EmployeeID";
                    parameter.Value = -1;
                    parameter.DbType = DbType.Int32;
                    command.Parameters.Add(parameter);

                    _dbConnection.Open();
                    using (IDataReader reader = await Task.Run(() => command.ExecuteReader()))
                    {
                        if (reader.Read())
                        {
                            List<Employee> employees = new List<Employee>();
                            do
                            {
                                employees.Add(new Employee
                                {
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    BloodGroup = reader["BloodGroup"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    PersonalEmailID = reader["PersonalEmailID"].ToString(),
                                    ContactNumber = reader["ContactNumber"].ToString(),
                                    AlternativeContactNumber = reader["AlternativeContactNumber"].ToString(),
                                    EmergencyContactNumber = reader["EmergencyContactNumber"].ToString(),
                                    AadhaarNumber = reader["AadhaarNumber"].ToString(),
                                    PanNumber = reader["PanNumber"].ToString(),
                                    AccountNumber = reader["AccountNumber"].ToString(),
                                    BankName = reader["BankName"].ToString(),
                                    IFSCCode = reader["IFSCCode"].ToString(),
                                    CommunicationAddress = reader["CommunicationAddress"].ToString(),
                                    PermanantAddress = reader["PermanantAddress"].ToString(),
                                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                    ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]),
                                    CreatedByID = Convert.ToInt32(reader["CreatedByID"]),
                                    ModifiedByID = Convert.ToInt32(reader["ModifiedByID"])
                                });
                            }
                            while (reader.Read());
                            return employees;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to get all the active employees", ex);
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbConnection.Close();
                }
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            try
            {
                using (var command = _dbConnection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetEmployeeByID]";
                    IDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@EmployeeID";
                    parameter.Value = employeeId;
                    parameter.DbType = DbType.Int32;
                    command.Parameters.Add(parameter);

                    _dbConnection.Open();
                    using (IDataReader reader = await Task.Run(() => command.ExecuteReader()))
                    {
                        if (reader.Read())
                        {
                            return new Employee
                            {
                                EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                BloodGroup = reader["BloodGroup"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                PersonalEmailID = reader["PersonalEmailID"].ToString(),
                                ContactNumber = reader["ContactNumber"].ToString(),
                                AlternativeContactNumber = reader["AlternativeContactNumber"].ToString(),
                                EmergencyContactNumber = reader["EmergencyContactNumber"].ToString(),
                                AadhaarNumber = reader["AadhaarNumber"].ToString(),
                                PanNumber = reader["PanNumber"].ToString(),
                                AccountNumber = reader["AccountNumber"].ToString(),
                                BankName = reader["BankName"].ToString(),
                                IFSCCode = reader["IFSCCode"].ToString(),
                                CommunicationAddress = reader["CommunicationAddress"].ToString(),
                                PermanantAddress = reader["PermanantAddress"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]),
                                CreatedByID = Convert.ToInt32(reader["CreatedByID"]),
                                ModifiedByID = Convert.ToInt32(reader["ModifiedByID"])

                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to get the employee by ID", ex);
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbConnection.Close();
                }
            }
        }

        public async Task<int> InsertEmployeeAsync(Employee employee)
        {
            try
            {
                using (IDbCommand command = _dbConnection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[SaveEmployeeInformation]";

                    AddParameter(command, "@FirstName", employee.FirstName, DbType.String);
                    AddParameter(command, "@LastName", employee.LastName, DbType.String);
                    AddParameter(command, "@BloodGroup", employee.BloodGroup, DbType.String);
                    AddParameter(command, "@Gender", employee.Gender, DbType.String);
                    AddParameter(command, "@PersonalEmailID", employee.PersonalEmailID, DbType.String);
                    AddParameter(command, "@ContactNumber", employee.ContactNumber, DbType.String);
                    AddParameter(command, "@AlternativeContactNumber", employee.AlternativeContactNumber, DbType.String);
                    AddParameter(command, "@EmergencyContactNumber", employee.EmergencyContactNumber, DbType.String);
                    AddParameter(command, "@AadhaarNumber", employee.AadhaarNumber, DbType.String);
                    AddParameter(command, "@PanNumber", employee.PanNumber, DbType.String);
                    AddParameter(command, "@AccountNumber", employee.AccountNumber, DbType.String);
                    AddParameter(command, "@BankName", employee.BankName, DbType.String);
                    AddParameter(command, "@IFSCCode", employee.IFSCCode, DbType.String);
                    AddParameter(command, "@CommunicationAddress", employee.CommunicationAddress, DbType.String);
                    AddParameter(command, "@PermanantAddress", employee.PermanantAddress, DbType.String);
                    AddParameter(command, "@DateOfBirth", employee.DateOfBirth, DbType.DateTime);
                    AddParameter(command, "@CreatedDate", employee.CreatedDate, DbType.DateTime);
                    AddParameter(command, "@ModifiedDate", employee.ModifiedDate, DbType.DateTime);
                    AddParameter(command, "@CreatedByID", employee.CreatedByID, DbType.Int32);
                    AddParameter(command, "@ModifiedByID", employee.ModifiedByID, DbType.Int32);

                    _dbConnection.Open();
                    var result = await Task.Run(() => command.ExecuteScalar());
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to create the employee", ex);
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbConnection.Close();
                }
            }
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                using (IDbCommand command = _dbConnection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[UpdateEmployee]";

                    AddParameter(command, "@EmployeeID", employee.EmployeeID, DbType.Int32);
                    AddParameter(command, "@FirstName", employee.FirstName, DbType.String);
                    AddParameter(command, "@LastName", employee.LastName, DbType.String);
                    AddParameter(command, "@BloodGroup", employee.BloodGroup, DbType.String);
                    AddParameter(command, "@Gender", employee.Gender, DbType.String);
                    AddParameter(command, "@PersonalEmailID", employee.PersonalEmailID, DbType.String);
                    AddParameter(command, "@ContactNumber", employee.ContactNumber, DbType.String);
                    AddParameter(command, "@AlternativeContactNumber", employee.AlternativeContactNumber, DbType.String);
                    AddParameter(command, "@EmergencyContactNumber", employee.EmergencyContactNumber, DbType.String);
                    AddParameter(command, "@AadhaarNumber", employee.AadhaarNumber, DbType.String);
                    AddParameter(command, "@PanNumber", employee.PanNumber, DbType.String);
                    AddParameter(command, "@AccountNumber", employee.AccountNumber, DbType.String);
                    AddParameter(command, "@BankName", employee.BankName, DbType.String);
                    AddParameter(command, "@IFSCCode", employee.IFSCCode, DbType.String);
                    AddParameter(command, "@CommunicationAddress", employee.CommunicationAddress, DbType.String);
                    AddParameter(command, "@PermanantAddress", employee.PermanantAddress, DbType.String);
                    AddParameter(command, "@DateOfBirth", employee.DateOfBirth, DbType.DateTime);
                    AddParameter(command, "@CreatedDate", employee.CreatedDate, DbType.DateTime);
                    AddParameter(command, "@ModifiedDate", employee.ModifiedDate, DbType.DateTime);
                    AddParameter(command, "@CreatedByID", employee.CreatedByID, DbType.Int32);
                    AddParameter(command, "@ModifiedByID", employee.ModifiedByID, DbType.Int32);

                    _dbConnection.Open();
                    await Task.Run(() => command.ExecuteNonQuery());
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to update the employee", ex);
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbConnection.Close();
                }
            }
        }

        private void AddParameter(IDbCommand command, string parameterName, object value, DbType dbType)
        {
            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value ?? DBNull.Value;
            parameter.DbType = dbType;
            command.Parameters.Add(parameter);
        }
    }
}
