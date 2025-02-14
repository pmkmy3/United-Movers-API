using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using united_movers_api.Models;
using united_movers_api.Repositories.Interfaces;

namespace united_movers_api.Repositories.Implementations
{
    public class RiderRepository : IRiderRepository
    {
        private readonly IDbConnection _dbConnection;

        public RiderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Rider>> GetAllRidersAsync()
        {
            var riders = new List<Rider>();
            var query = "SELECT * FROM Riders"; // Adjust the query according to your table schema

            using (var command = _dbConnection.CreateCommand())
            {
                command.CommandText = query;
                _dbConnection.Open();
                using (var reader = await ((DbCommand)command).ExecuteReaderAsync(CommandBehavior.CloseConnection))
                {
                    while (await reader.ReadAsync())
                    {
                        var rider = new Rider
                        {
                            RiderID = reader.GetInt32(reader.GetOrdinal("RiderID")),
                            VendorID = reader.GetInt32(reader.GetOrdinal("VendorID")),
                            ReferenceName = reader.GetString(reader.GetOrdinal("ReferenceName")),
                            RiderName = reader.GetString(reader.GetOrdinal("RiderName")),
                            Gender = reader.GetString(reader.GetOrdinal("Gender")),
                            DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                            AadharCardNumber = reader.GetString(reader.GetOrdinal("AadharCardNumber")),
                            PANNumber = reader.GetString(reader.GetOrdinal("PANNumber")),
                            BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup")),
                            ContactNumber = reader.GetString(reader.GetOrdinal("ContactNumber")),
                            EmailID = reader.GetString(reader.GetOrdinal("EmailID")),
                            AlternativeContactNumber = reader.GetString(reader.GetOrdinal("AlternativeContactNumber")),
                            AlternativeEmail = reader.GetString(reader.GetOrdinal("AlternativeEmail")),
                            EmergencyContactName = reader.GetString(reader.GetOrdinal("EmergencyContactName")),
                            EmergencyContactRelation = reader.GetString(reader.GetOrdinal("EmergencyContactRelation")),
                            EmergencyContactPersonID = reader.GetString(reader.GetOrdinal("EmergencyContactPersonID")),
                            EmergencyContactNumber = reader.GetString(reader.GetOrdinal("EmergencyContactNumber")),
                            AddressLine1 = reader.GetString(reader.GetOrdinal("AddressLine1")),
                            AddressLine2 = reader.GetString(reader.GetOrdinal("AddressLine2")),
                            State = reader.GetString(reader.GetOrdinal("State")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            Zip = reader.GetString(reader.GetOrdinal("Zip")),
                            Landmark = reader.GetString(reader.GetOrdinal("Landmark")),
                            HighestDegreeEarned = reader.GetString(reader.GetOrdinal("HighestDegreeEarned")),
                            PreviousOrgName = reader.GetString(reader.GetOrdinal("PreviousOrgName")),
                            AccountNumber = reader.GetString(reader.GetOrdinal("AccountNumber")),
                            BankName = reader.GetString(reader.GetOrdinal("BankName")),
                            IFSCCode = reader.GetString(reader.GetOrdinal("IFSCCode")),
                            UANNumber = reader.GetString(reader.GetOrdinal("UANNumber")),
                            InsurancePolicyNumber = reader.GetString(reader.GetOrdinal("InsurancePolicyNumber")),
                            InsurerName = reader.GetString(reader.GetOrdinal("InsurerName")),
                            InsuranceStartDate = reader.IsDBNull(reader.GetOrdinal("InsuranceStartDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("InsuranceStartDate")),
                            InsuranceEndDate = reader.IsDBNull(reader.GetOrdinal("InsuranceEndDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("InsuranceEndDate")),
                            FamilyMemberName = reader.GetString(reader.GetOrdinal("FamilyMemberName")),
                            FamilyMemberRelation = reader.GetString(reader.GetOrdinal("FamilyMemberRelation")),
                            FamilyMemberIDType = reader.GetString(reader.GetOrdinal("FamilyMemberIDType")),
                            FamilyMemberID = reader.GetString(reader.GetOrdinal("FamilyMemberID")),
                            FamilyMemberContact = reader.GetString(reader.GetOrdinal("FamilyMemberContact")),
                            IsBackgroundVerificationCompleted = reader.IsDBNull(reader.GetOrdinal("IsBackgroundVerificationCompleted")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("IsBackgroundVerificationCompleted")),
                            IsPhysicalVerificationCompleted = reader.IsDBNull(reader.GetOrdinal("IsPhysicalVerificationCompleted")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("IsPhysicalVerificationCompleted")),
                            BackgroundVerificationAgencyName = reader.GetString(reader.GetOrdinal("BackgroundVerificationAgencyName")),
                            IsAadhaarVerified = reader.IsDBNull(reader.GetOrdinal("IsAadhaarVerified")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("IsAadhaarVerified")),
                            IsContactNumberVerified = reader.IsDBNull(reader.GetOrdinal("IsContactNumberVerified")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("IsContactNumberVerified")),
                            AdditionalNotes = reader.GetString(reader.GetOrdinal("AdditionalNotes"))
                        };
                        riders.Add(rider);
                    }
                }
            }
            return riders;
        }

        public async Task<Rider> GetRiderByIdAsync(int id)
        {
            Rider rider = null;
            var query = "SELECT * FROM Riders WHERE RiderID = @RiderID"; // Adjust the query according to your table schema

            using (var command = _dbConnection.CreateCommand())
            {
                command.CommandText = query;
                var parameter = command.CreateParameter();
                parameter.ParameterName = "@RiderID";
                parameter.Value = id;
                command.Parameters.Add(parameter);

                _dbConnection.Open();
                using (var reader = await ((DbCommand)command).ExecuteReaderAsync(CommandBehavior.CloseConnection))
                {
                    if (await reader.ReadAsync())
                    {
                        rider = new Rider
                        {
                            RiderID = reader.GetInt32(reader.GetOrdinal("RiderID")),
                            VendorID = reader.GetInt32(reader.GetOrdinal("VendorID")),
                            ReferenceName = reader.GetString(reader.GetOrdinal("ReferenceName")),
                            RiderName = reader.GetString(reader.GetOrdinal("RiderName")),
                            Gender = reader.GetString(reader.GetOrdinal("Gender")),
                            DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                            AadharCardNumber = reader.GetString(reader.GetOrdinal("AadharCardNumber")),
                            PANNumber = reader.GetString(reader.GetOrdinal("PANNumber")),
                            BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup")),
                            ContactNumber = reader.GetString(reader.GetOrdinal("ContactNumber")),
                            EmailID = reader.GetString(reader.GetOrdinal("EmailID")),
                            AlternativeContactNumber = reader.GetString(reader.GetOrdinal("AlternativeContactNumber")),
                            AlternativeEmail = reader.GetString(reader.GetOrdinal("AlternativeEmail")),
                            EmergencyContactName = reader.GetString(reader.GetOrdinal("EmergencyContactName")),
                            EmergencyContactRelation = reader.GetString(reader.GetOrdinal("EmergencyContactRelation")),
                            EmergencyContactPersonID = reader.GetString(reader.GetOrdinal("EmergencyContactPersonID")),
                            EmergencyContactNumber = reader.GetString(reader.GetOrdinal("EmergencyContactNumber")),
                            AddressLine1 = reader.GetString(reader.GetOrdinal("AddressLine1")),
                            AddressLine2 = reader.GetString(reader.GetOrdinal("AddressLine2")),
                            State = reader.GetString(reader.GetOrdinal("State")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            Zip = reader.GetString(reader.GetOrdinal("Zip")),
                            Landmark = reader.GetString(reader.GetOrdinal("Landmark")),
                            HighestDegreeEarned = reader.GetString(reader.GetOrdinal("HighestDegreeEarned")),
                            PreviousOrgName = reader.GetString(reader.GetOrdinal("PreviousOrgName")),
                            AccountNumber = reader.GetString(reader.GetOrdinal("AccountNumber")),
                            BankName = reader.GetString(reader.GetOrdinal("BankName")),
                            IFSCCode = reader.GetString(reader.GetOrdinal("IFSCCode")),
                            UANNumber = reader.GetString(reader.GetOrdinal("UANNumber")),
                            InsurancePolicyNumber = reader.GetString(reader.GetOrdinal("InsurancePolicyNumber")),
                            InsurerName = reader.GetString(reader.GetOrdinal("InsurerName")),
                            InsuranceStartDate = reader.IsDBNull(reader.GetOrdinal("InsuranceStartDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("InsuranceStartDate")),
                            InsuranceEndDate = reader.IsDBNull(reader.GetOrdinal("InsuranceEndDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("InsuranceEndDate")),
                            FamilyMemberName = reader.GetString(reader.GetOrdinal("FamilyMemberName")),
                            FamilyMemberRelation = reader.GetString(reader.GetOrdinal("FamilyMemberRelation")),
                            FamilyMemberIDType = reader.GetString(reader.GetOrdinal("FamilyMemberIDType")),
                            FamilyMemberID = reader.GetString(reader.GetOrdinal("FamilyMemberID")),
                            FamilyMemberContact = reader.GetString(reader.GetOrdinal("FamilyMemberContact")),
                            IsBackgroundVerificationCompleted = reader.IsDBNull(reader.GetOrdinal("IsBackgroundVerificationCompleted")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("IsBackgroundVerificationCompleted")),
                            IsPhysicalVerificationCompleted = reader.IsDBNull(reader.GetOrdinal("IsPhysicalVerificationCompleted")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("IsPhysicalVerificationCompleted")),
                            BackgroundVerificationAgencyName = reader.GetString(reader.GetOrdinal("BackgroundVerificationAgencyName")),
                            IsAadhaarVerified = reader.IsDBNull(reader.GetOrdinal("IsAadhaarVerified")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("IsAadhaarVerified")),
                            IsContactNumberVerified = reader.IsDBNull(reader.GetOrdinal("IsContactNumberVerified")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("IsContactNumberVerified")),
                            AdditionalNotes = reader.GetString(reader.GetOrdinal("AdditionalNotes"))
                        };
                    }
                }
            }
            return rider;
        }

        public async Task<Rider> CreateRiderAsync(Rider rider)
        {
            var query = @"INSERT INTO Riders (VendorID, ReferenceName, RiderName, Gender, DateOfBirth, AadharCardNumber, PANNumber, BloodGroup, ContactNumber, EmailID, AlternativeContactNumber, AlternativeEmail, EmergencyContactName, EmergencyContactRelation, EmergencyContactPersonID, EmergencyContactNumber, AddressLine1, AddressLine2, State, City, Zip, Landmark, HighestDegreeEarned, PreviousOrgName, AccountNumber, BankName, IFSCCode, UANNumber, InsurancePolicyNumber, InsurerName, InsuranceStartDate, InsuranceEndDate, FamilyMemberName, FamilyMemberRelation, FamilyMemberIDType, FamilyMemberID, FamilyMemberContact, IsBackgroundVerificationCompleted, IsPhysicalVerificationCompleted, BackgroundVerificationAgencyName, IsAadhaarVerified, IsContactNumberVerified, AdditionalNotes) 
                          VALUES (@VendorID, @ReferenceName, @RiderName, @Gender, @DateOfBirth, @AadharCardNumber, @PANNumber, @BloodGroup, @ContactNumber, @EmailID, @AlternativeContactNumber, @AlternativeEmail, @EmergencyContactName, @EmergencyContactRelation, @EmergencyContactPersonID, @EmergencyContactNumber, @AddressLine1, @AddressLine2, @State, @City, @Zip, @Landmark, @HighestDegreeEarned, @PreviousOrgName, @AccountNumber, @BankName, @IFSCCode, @UANNumber, @InsurancePolicyNumber, @InsurerName, @InsuranceStartDate, @InsuranceEndDate, @FamilyMemberName, @FamilyMemberRelation, @FamilyMemberIDType, @FamilyMemberID, @FamilyMemberContact, @IsBackgroundVerificationCompleted, @IsPhysicalVerificationCompleted, @BackgroundVerificationAgencyName, @IsAadhaarVerified, @IsContactNumberVerified, @AdditionalNotes);
                          SELECT CAST(scope_identity() AS int)";

            using (var command = _dbConnection.CreateCommand())
            {
                command.CommandText = query;

                command.Parameters.Add(new SqlParameter("@VendorID", rider.VendorID));
                command.Parameters.Add(new SqlParameter("@ReferenceName", rider.ReferenceName));
                command.Parameters.Add(new SqlParameter("@RiderName", rider.RiderName));
                command.Parameters.Add(new SqlParameter("@Gender", rider.Gender));
                command.Parameters.Add(new SqlParameter("@DateOfBirth", rider.DateOfBirth));
                command.Parameters.Add(new SqlParameter("@AadharCardNumber", rider.AadharCardNumber));
                command.Parameters.Add(new SqlParameter("@PANNumber", rider.PANNumber));
                command.Parameters.Add(new SqlParameter("@BloodGroup", rider.BloodGroup));
                command.Parameters.Add(new SqlParameter("@ContactNumber", rider.ContactNumber));
                command.Parameters.Add(new SqlParameter("@EmailID", rider.EmailID));
                command.Parameters.Add(new SqlParameter("@AlternativeContactNumber", rider.AlternativeContactNumber));
                command.Parameters.Add(new SqlParameter("@AlternativeEmail", rider.AlternativeEmail));
                command.Parameters.Add(new SqlParameter("@EmergencyContactName", rider.EmergencyContactName));
                command.Parameters.Add(new SqlParameter("@EmergencyContactRelation", rider.EmergencyContactRelation));
                command.Parameters.Add(new SqlParameter("@EmergencyContactPersonID", rider.EmergencyContactPersonID));
                command.Parameters.Add(new SqlParameter("@EmergencyContactNumber", rider.EmergencyContactNumber));
                command.Parameters.Add(new SqlParameter("@AddressLine1", rider.AddressLine1));
                command.Parameters.Add(new SqlParameter("@AddressLine2", rider.AddressLine2));
                command.Parameters.Add(new SqlParameter("@State", rider.State));
                command.Parameters.Add(new SqlParameter("@City", rider.City));
                command.Parameters.Add(new SqlParameter("@Zip", rider.Zip));
                command.Parameters.Add(new SqlParameter("@Landmark", rider.Landmark));
                command.Parameters.Add(new SqlParameter("@HighestDegreeEarned", rider.HighestDegreeEarned));
                command.Parameters.Add(new SqlParameter("@PreviousOrgName", rider.PreviousOrgName));
                command.Parameters.Add(new SqlParameter("@AccountNumber", rider.AccountNumber));
                command.Parameters.Add(new SqlParameter("@BankName", rider.BankName));
                command.Parameters.Add(new SqlParameter("@IFSCCode", rider.IFSCCode));
                command.Parameters.Add(new SqlParameter("@UANNumber", rider.UANNumber));
                command.Parameters.Add(new SqlParameter("@InsurancePolicyNumber", rider.InsurancePolicyNumber));
                command.Parameters.Add(new SqlParameter("@InsurerName", rider.InsurerName));
                command.Parameters.Add(new SqlParameter("@InsuranceStartDate", rider.InsuranceStartDate));
                command.Parameters.Add(new SqlParameter("@InsuranceEndDate", rider.InsuranceEndDate));
                command.Parameters.Add(new SqlParameter("@FamilyMemberName", rider.FamilyMemberName));
                command.Parameters.Add(new SqlParameter("@FamilyMemberRelation", rider.FamilyMemberRelation));
                command.Parameters.Add(new SqlParameter("@FamilyMemberIDType", rider.FamilyMemberIDType));
                command.Parameters.Add(new SqlParameter("@FamilyMemberID", rider.FamilyMemberID));
                command.Parameters.Add(new SqlParameter("@FamilyMemberContact", rider.FamilyMemberContact));
                command.Parameters.Add(new SqlParameter("@IsBackgroundVerificationCompleted", rider.IsBackgroundVerificationCompleted));
                command.Parameters.Add(new SqlParameter("@IsPhysicalVerificationCompleted", rider.IsPhysicalVerificationCompleted));
                command.Parameters.Add(new SqlParameter("@BackgroundVerificationAgencyName", rider.BackgroundVerificationAgencyName));
                command.Parameters.Add(new SqlParameter("@IsAadhaarVerified", rider.IsAadhaarVerified));
                command.Parameters.Add(new SqlParameter("@IsContactNumberVerified", rider.IsContactNumberVerified));
                command.Parameters.Add(new SqlParameter("@AdditionalNotes", rider.AdditionalNotes));

                _dbConnection.Open();
                rider.RiderID = (int)await ((DbCommand)command).ExecuteScalarAsync();
            }

            return rider;
        }

        public async Task<Rider> UpdateRiderAsync(int id, Rider rider)
        {
            var query = @"UPDATE Riders SET VendorID = @VendorID, ReferenceName = @ReferenceName, RiderName = @RiderName, Gender = @Gender, DateOfBirth = @DateOfBirth, AadharCardNumber = @AadharCardNumber, PANNumber = @PANNumber, BloodGroup = @BloodGroup, ContactNumber = @ContactNumber, EmailID = @EmailID, AlternativeContactNumber = @AlternativeContactNumber, AlternativeEmail = @AlternativeEmail, EmergencyContactName = @EmergencyContactName, EmergencyContactRelation = @EmergencyContactRelation, EmergencyContactPersonID = @EmergencyContactPersonID, EmergencyContactNumber = @EmergencyContactNumber, AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2, State = @State, City = @City, Zip = @Zip, Landmark = @Landmark, HighestDegreeEarned = @HighestDegreeEarned, PreviousOrgName = @PreviousOrgName, AccountNumber = @AccountNumber, BankName = @BankName, IFSCCode = @IFSCCode, UANNumber = @UANNumber, InsurancePolicyNumber = @InsurancePolicyNumber, InsurerName = @InsurerName, InsuranceStartDate = @InsuranceStartDate, InsuranceEndDate = @InsuranceEndDate, FamilyMemberName = @FamilyMemberName, FamilyMemberRelation = @FamilyMemberRelation, FamilyMemberIDType = @FamilyMemberIDType, FamilyMemberID = @FamilyMemberID, FamilyMemberContact = @FamilyMemberContact, IsBackgroundVerificationCompleted = @IsBackgroundVerificationCompleted, IsPhysicalVerificationCompleted = @IsPhysicalVerificationCompleted, BackgroundVerificationAgencyName = @BackgroundVerificationAgencyName, IsAadhaarVerified = @IsAadhaarVerified, IsContactNumberVerified = @IsContactNumberVerified, AdditionalNotes = @AdditionalNotes WHERE RiderID = @RiderID";

            using (var command = _dbConnection.CreateCommand())
            {
                command.CommandText = query;

                command.Parameters.Add(new SqlParameter("@VendorID", rider.VendorID));
                command.Parameters.Add(new SqlParameter("@ReferenceName", rider.ReferenceName));
                command.Parameters.Add(new SqlParameter("@RiderName", rider.RiderName));
                command.Parameters.Add(new SqlParameter("@Gender", rider.Gender));
                command.Parameters.Add(new SqlParameter("@DateOfBirth", rider.DateOfBirth));
                command.Parameters.Add(new SqlParameter("@AadharCardNumber", rider.AadharCardNumber));
                command.Parameters.Add(new SqlParameter("@PANNumber", rider.PANNumber));
                command.Parameters.Add(new SqlParameter("@BloodGroup", rider.BloodGroup));
                command.Parameters.Add(new SqlParameter("@ContactNumber", rider.ContactNumber));
                command.Parameters.Add(new SqlParameter("@EmailID", rider.EmailID));
                command.Parameters.Add(new SqlParameter("@AlternativeContactNumber", rider.AlternativeContactNumber));
                command.Parameters.Add(new SqlParameter("@AlternativeEmail", rider.AlternativeEmail));
                command.Parameters.Add(new SqlParameter("@EmergencyContactName", rider.EmergencyContactName));
                command.Parameters.Add(new SqlParameter("@EmergencyContactRelation", rider.EmergencyContactRelation));
                command.Parameters.Add(new SqlParameter("@EmergencyContactPersonID", rider.EmergencyContactPersonID));
                command.Parameters.Add(new SqlParameter("@EmergencyContactNumber", rider.EmergencyContactNumber));
                command.Parameters.Add(new SqlParameter("@AddressLine1", rider.AddressLine1));
                command.Parameters.Add(new SqlParameter("@AddressLine2", rider.AddressLine2));
                command.Parameters.Add(new SqlParameter("@State", rider.State));
                command.Parameters.Add(new SqlParameter("@City", rider.City));
                command.Parameters.Add(new SqlParameter("@Zip", rider.Zip));
                command.Parameters.Add(new SqlParameter("@Landmark", rider.Landmark));
                command.Parameters.Add(new SqlParameter("@HighestDegreeEarned", rider.HighestDegreeEarned));
                command.Parameters.Add(new SqlParameter("@PreviousOrgName", rider.PreviousOrgName));
                command.Parameters.Add(new SqlParameter("@AccountNumber", rider.AccountNumber));
                command.Parameters.Add(new SqlParameter("@BankName", rider.BankName));
                command.Parameters.Add(new SqlParameter("@IFSCCode", rider.IFSCCode));
                command.Parameters.Add(new SqlParameter("@UANNumber", rider.UANNumber));
                command.Parameters.Add(new SqlParameter("@InsurancePolicyNumber", rider.InsurancePolicyNumber));
                command.Parameters.Add(new SqlParameter("@InsurerName", rider.InsurerName));
                command.Parameters.Add(new SqlParameter("@InsuranceStartDate", rider.InsuranceStartDate));
                command.Parameters.Add(new SqlParameter("@InsuranceEndDate", rider.InsuranceEndDate));
                command.Parameters.Add(new SqlParameter("@FamilyMemberName", rider.FamilyMemberName));
                command.Parameters.Add(new SqlParameter("@FamilyMemberRelation", rider.FamilyMemberRelation));
                command.Parameters.Add(new SqlParameter("@FamilyMemberIDType", rider.FamilyMemberIDType));
                command.Parameters.Add(new SqlParameter("@FamilyMemberID", rider.FamilyMemberID));
                command.Parameters.Add(new SqlParameter("@FamilyMemberContact", rider.FamilyMemberContact));
                command.Parameters.Add(new SqlParameter("@IsBackgroundVerificationCompleted", rider.IsBackgroundVerificationCompleted));
                command.Parameters.Add(new SqlParameter("@IsPhysicalVerificationCompleted", rider.IsPhysicalVerificationCompleted));
                command.Parameters.Add(new SqlParameter("@BackgroundVerificationAgencyName", rider.BackgroundVerificationAgencyName));
                command.Parameters.Add(new SqlParameter("@IsAadhaarVerified", rider.IsAadhaarVerified));
                command.Parameters.Add(new SqlParameter("@IsContactNumberVerified", rider.IsContactNumberVerified));
                command.Parameters.Add(new SqlParameter("@AdditionalNotes", rider.AdditionalNotes));
                command.Parameters.Add(new SqlParameter("@RiderID", id));

                _dbConnection.Open();
                await ((DbCommand)command).ExecuteNonQueryAsync();
            }

            return rider;
        }

        public async Task<bool> DeleteRiderAsync(int id)
        {
            var query = "DELETE FROM Riders WHERE RiderID = @RiderID";

            using (var command = _dbConnection.CreateCommand())
            {
                command.CommandText = query;
                var parameter = command.CreateParameter();
                parameter.ParameterName = "@RiderID";
                parameter.Value = id;
                command.Parameters.Add(parameter);

                _dbConnection.Open();
                var result = await ((DbCommand)command).ExecuteNonQueryAsync();
                return result > 0;
            }
        }
    }
}
