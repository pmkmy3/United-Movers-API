﻿using Microsoft.Data.SqlClient;
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
#pragma warning disable CS8601 // Possible null reference assignment.
                                employees.Add(new Employee
                                {
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    FirstName = reader["FirstName"]?.ToString(),
                                    LastName = reader["LastName"]?.ToString(),
                                    BloodGroup = reader["BloodGroup"]?.ToString(),
                                    Gender = reader["Gender"]?.ToString(),
                                    PersonalEmailID = reader["PersonalEmailID"]?.ToString(),
                                    ContactNumber = reader["ContactNumber"]?.ToString(),
                                    AlternativeContactNumber = reader["AlternativeContactNumber"]?.ToString(),
                                    EmergencyContactNumber = reader["EmergencyContactNumber"]?.ToString(),
                                    AadhaarNumber = reader["AadhaarNumber"]?.ToString(),
                                    PanNumber = reader["PanNumber"]?.ToString(),
                                    AccountNumber = reader["AccountNumber"]?.ToString(),
                                    BankName = reader["BankName"]?.ToString(),
                                    IFSCCode = reader["IFSCCode"]?.ToString(),
                                    DateOfBirth = reader["DateOfBirth"] != null ? Convert.ToDateTime(reader["DateOfBirth"]) : null,
                                    CreatedDate = reader["CreatedDate"] != null ? Convert.ToDateTime(reader["CreatedDate"]) : null,
                                    ModifiedDate = reader["ModifiedDate"] != null ? Convert.ToDateTime(reader["ModifiedDate"]) : null,
                                    CreatedByID = reader["CreatedByID"] != null ? Convert.ToInt32(reader["CreatedByID"]) : -1,
                                    ModifiedByID = reader["ModifiedByID"] != null ? Convert.ToInt32(reader["ModifiedByID"]) : -1,
                                    AlternativeEmail = reader["AlternativeEmail"]?.ToString(),
                                    EmergencyContactName = reader["EmergencyContactName"]?.ToString(),
                                    EmergencyContactRelation = reader["EmergencyContactRelation"]?.ToString(),
                                    EmergencyContactPersonID = reader["EmergencyContactPersonID"]?.ToString(),
                                    AddressLine1 = reader["AddressLine1"]?.ToString(),
                                    AddressLine2 = reader["AddressLine2"]?.ToString(),
                                    State = reader["State"]?.ToString(),
                                    City = reader["City"]?.ToString(),
                                    Zip = reader["Zip"]?.ToString(),
                                    Landmark = reader["Landmark"]?.ToString(),
                                    HighestDegreeEarned = reader["HighestDegreeEarned"]?.ToString(),
                                    PreviousOrgName = reader["PreviousOrgName"]?.ToString(),
                                    UANNumber = reader["UANNumber"]?.ToString(),
                                    InsurancePolicyNumber = reader["InsurancePolicyNumber"]?.ToString(),
                                    InsurerName = reader["InsurerName"]?.ToString(),
                                    InsuranceStartDate = reader["InsuranceStartDate"] != null ? Convert.ToDateTime(reader["InsuranceStartDate"]) : null,
                                    InsuranceEndDate = reader["InsuranceEndDate"] != null ? Convert.ToDateTime(reader["InsuranceEndDate"]) : null,
                                    IsBackgroundVerificationCompleted = reader["IsBackgroundVerficationCompleted"] != null ?  Convert.ToBoolean(reader["IsBackgroundVerficationCompleted"]) : false,
                                    IsPhysicalVerificationCompleted = reader["IsPhysicalVerificationCompleted"] != null ? Convert.ToBoolean(reader["IsPhysicalVerificationCompleted"]) : false,
                                    BackgroundVerificationAgencyName = reader["BackgroundVerificationAgencyName"]?.ToString()
                                });
#pragma warning restore CS8601 // Possible null reference assignment.
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
                    AddParameter(command, "@EmployeeID", employeeId, DbType.Int32);

                    _dbConnection.Open();
                    using (IDataReader reader = await Task.Run(() => command.ExecuteReader()))
                    {
                        if (reader.Read())
                        {
#pragma warning disable CS8601 // Possible null reference assignment.
                            return new Employee
                            {
                                EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                FirstName = reader["FirstName"]?.ToString(),
                                LastName = reader["LastName"]?.ToString(),
                                BloodGroup = reader["BloodGroup"]?.ToString(),
                                Gender = reader["Gender"]?.ToString(),
                                PersonalEmailID = reader["PersonalEmailID"]?.ToString(),
                                ContactNumber = reader["ContactNumber"]?.ToString(),
                                AlternativeContactNumber = reader["AlternativeContactNumber"]?.ToString(),
                                EmergencyContactNumber = reader["EmergencyContactNumber"]?.ToString(),
                                AadhaarNumber = reader["AadhaarNumber"]?.ToString(),
                                PanNumber = reader["PanNumber"]?.ToString(),
                                AccountNumber = reader["AccountNumber"]?.ToString(),
                                BankName = reader["BankName"]?.ToString(),
                                IFSCCode = reader["IFSCCode"]?.ToString(),
                                DateOfBirth = reader["DateOfBirth"] != null ? Convert.ToDateTime(reader["DateOfBirth"]) : null,
                                CreatedDate = reader["CreatedDate"] != null ? Convert.ToDateTime(reader["CreatedDate"]) : null,
                                ModifiedDate = reader["ModifiedDate"] != null ? Convert.ToDateTime(reader["ModifiedDate"]) : null,
                                CreatedByID = reader["CreatedByID"] != null ? Convert.ToInt32(reader["CreatedByID"]) : -1,
                                ModifiedByID = reader["ModifiedByID"] != null ? Convert.ToInt32(reader["ModifiedByID"]) : -1,
                                AlternativeEmail = reader["AlternativeEmail"]?.ToString(),
                                EmergencyContactName = reader["EmergencyContactName"]?.ToString(),
                                EmergencyContactRelation = reader["EmergencyContactRelation"]?.ToString(),
                                EmergencyContactPersonID = reader["EmergencyContactPersonID"]?.ToString(),
                                AddressLine1 = reader["AddressLine1"]?.ToString(),
                                AddressLine2 = reader["AddressLine2"]?.ToString(),
                                State = reader["State"]?.ToString(),
                                City = reader["City"]?.ToString(),
                                Zip = reader["Zip"]?.ToString(),
                                Landmark = reader["Landmark"]?.ToString(),
                                HighestDegreeEarned = reader["HighestDegreeEarned"]?.ToString(),
                                PreviousOrgName = reader["PreviousOrgName"]?.ToString(),
                                UANNumber = reader["UANNumber"]?.ToString(),
                                InsurancePolicyNumber = reader["InsurancePolicyNumber"]?.ToString(),
                                InsurerName = reader["InsurerName"]?.ToString(),
                                InsuranceStartDate = reader["InsuranceStartDate"] != null ? Convert.ToDateTime(reader["InsuranceStartDate"]) : null,
                                InsuranceEndDate = reader["InsuranceEndDate"] != null ? Convert.ToDateTime(reader["InsuranceEndDate"]) : null,
                                IsBackgroundVerificationCompleted = reader["IsBackgroundVerficationCompleted"] != null ? Convert.ToBoolean(reader["IsBackgroundVerficationCompleted"]) : false,
                                IsPhysicalVerificationCompleted = reader["IsPhysicalVerificationCompleted"] != null ? Convert.ToBoolean(reader["IsPhysicalVerificationCompleted"]) : false,
                                BackgroundVerificationAgencyName = reader["BackgroundVerificationAgencyName"]?.ToString()
                            };
#pragma warning restore CS8601 // Possible null reference assignment.
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
                    AddParameter(command, "@DateOfBirth", employee.DateOfBirth != null ? employee.DateOfBirth.Value : DBNull.Value, DbType.DateTime);
                    AddParameter(command, "@CreatedDate", employee.CreatedDate != null ? employee.CreatedDate.Value : DBNull.Value, DbType.DateTime);
                    AddParameter(command, "@ModifiedDate", employee.ModifiedDate != null ? employee.ModifiedDate.Value : DBNull.Value, DbType.DateTime);
                    AddParameter(command, "@CreatedByID", employee.CreatedByID, DbType.Int32);
                    AddParameter(command, "@ModifiedByID", employee.ModifiedByID, DbType.Int32);
                    AddParameter(command, "@AlternativeEmail", employee.AlternativeEmail, DbType.String);
                    AddParameter(command, "@EmergencyContactName", employee.EmergencyContactName, DbType.String);
                    AddParameter(command, "@EmergencyContactRelation", employee.EmergencyContactRelation, DbType.String);
                    AddParameter(command, "@EmergencyContactPersonID", employee.EmergencyContactPersonID, DbType.Int32);
                    AddParameter(command, "@AddressLine1", employee.AddressLine1, DbType.String);
                    AddParameter(command, "@AddressLine2", employee.AddressLine2, DbType.String);
                    AddParameter(command, "@State", employee.State, DbType.String);
                    AddParameter(command, "@City", employee.City, DbType.String);
                    AddParameter(command, "@Zip", employee.Zip, DbType.String);
                    AddParameter(command, "@Landmark", employee.Landmark, DbType.String);
                    AddParameter(command, "@HighestDegreeEarned", employee.HighestDegreeEarned, DbType.String);
                    AddParameter(command, "@PreviousOrgName", employee.PreviousOrgName, DbType.String);
                    AddParameter(command, "@UANNumber", employee.UANNumber, DbType.String);
                    AddParameter(command, "@InsurancePolicyNumber", employee.InsurancePolicyNumber, DbType.String);
                    AddParameter(command, "@InsurerName", employee.InsurerName, DbType.String);
                    AddParameter(command, "@InsuranceStartDate", employee.InsuranceStartDate != null ? employee.InsuranceStartDate.Value : DBNull.Value, DbType.DateTime);
                    AddParameter(command, "@InsuranceEndDate", employee.InsuranceEndDate != null ? employee.InsuranceEndDate.Value : DBNull.Value, DbType.DateTime);
                    AddParameter(command, "@IsBackgroundVerificationCompleted", employee.IsBackgroundVerificationCompleted, DbType.Boolean);
                    AddParameter(command, "@IsPhysicalVerificationCompleted", employee.IsPhysicalVerificationCompleted, DbType.Boolean);
                    AddParameter(command, "@BackgroundVerificationAgencyName", employee.BackgroundVerificationAgencyName, DbType.String);

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
                    AddParameter(command, "@DateOfBirth", employee.DateOfBirth != null ? employee.DateOfBirth.Value : DBNull.Value, DbType.DateTime);
                    AddParameter(command, "@CreatedDate", employee.CreatedDate != null ? employee.CreatedDate.Value : DBNull.Value, DbType.DateTime);
                    AddParameter(command, "@ModifiedDate", employee.ModifiedDate != null ? employee.ModifiedDate.Value : DBNull.Value, DbType.DateTime);
                    AddParameter(command, "@CreatedByID", employee.CreatedByID, DbType.Int32);
                    AddParameter(command, "@ModifiedByID", employee.ModifiedByID, DbType.Int32);
                    AddParameter(command, "@AlternativeEmail", employee.AlternativeEmail, DbType.String);
                    AddParameter(command, "@EmergencyContactName", employee.EmergencyContactName, DbType.String);
                    AddParameter(command, "@EmergencyContactRelation", employee.EmergencyContactRelation, DbType.String);
                    AddParameter(command, "@EmergencyContactPersonID", employee.EmergencyContactPersonID, DbType.Int32);
                    AddParameter(command, "@AddressLine1", employee.AddressLine1, DbType.String);
                    AddParameter(command, "@AddressLine2", employee.AddressLine2, DbType.String);
                    AddParameter(command, "@State", employee.State, DbType.String);
                    AddParameter(command, "@City", employee.City, DbType.String);
                    AddParameter(command, "@Zip", employee.Zip, DbType.String);
                    AddParameter(command, "@Landmark", employee.Landmark, DbType.String);
                    AddParameter(command, "@HighestDegreeEarned", employee.HighestDegreeEarned, DbType.String);
                    AddParameter(command, "@PreviousOrgName", employee.PreviousOrgName, DbType.String);
                    AddParameter(command, "@UANNumber", employee.UANNumber, DbType.String);
                    AddParameter(command, "@InsurancePolicyNumber", employee.InsurancePolicyNumber, DbType.String);
                    AddParameter(command, "@InsurerName", employee.InsurerName, DbType.String);
                    AddParameter(command, "@InsuranceStartDate", employee.InsuranceStartDate != null ? employee.InsuranceStartDate.Value : DBNull.Value, DbType.DateTime);
                    AddParameter(command, "@InsuranceEndDate", employee.InsuranceEndDate != null ? employee.InsuranceEndDate.Value : DBNull.Value, DbType.DateTime);
                    AddParameter(command, "@IsBackgroundVerificationCompleted", employee.IsBackgroundVerificationCompleted, DbType.Boolean);
                    AddParameter(command, "@IsPhysicalVerificationCompleted", employee.IsPhysicalVerificationCompleted, DbType.Boolean);
                    AddParameter(command, "@BackgroundVerificationAgencyName", employee.BackgroundVerificationAgencyName, DbType.String);

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
