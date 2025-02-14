using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using united_movers_api.Models;

namespace united_movers_api.Services
{
    public class RiderService : IRiderService
    {
        private readonly IDbConnection _dbConnection;

        public RiderService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Rider>> GetAllRidersAsync()
        {
            var sql = "SELECT * FROM Riders";
            return await _dbConnection.QueryAsync<Rider>(sql);
        }

        public async Task<Rider> GetRiderByIdAsync(int id)
        {
            var sql = "EXEC spGetRiderById @RiderID";
            return await _dbConnection.QueryFirstOrDefaultAsync<Rider>(sql, new { RiderID = id });
        }

        public async Task<Rider> CreateRiderAsync(Rider rider)
        {
            var sql = @"EXEC spCreateRider @VendorID, @ReferenceName, @RiderName, @Gender, @DateOfBirth, @AadharCardNumber, @PANNumber, @BloodGroup, @ContactNumber, @EmailID, @AlternativeContactNumber, @AlternativeEmail, @EmergencyContactName, @EmergencyContactRelation, @EmergencyContactPersonID, @EmergencyContactNumber, @AddressLine1, @AddressLine2, @State, @City, @Zip, @Landmark, @HighestDegreeEarned, @PreviousOrgName, @AccountNumber, @BankName, @IFSCCode, @UANNumber, @InsurancePolicyNumber, @InsurerName, @InsuranceStartDate, @InsuranceEndDate, @FamilyMemberName, @FamilyMemberRelation, @FamilyMemberIDType, @FamilyMemberID, @FamilyMemberContact, @IsBackgroundVerificationCompleted, @IsPhysicalVerificationCompleted, @BackgroundVerificationAgencyName, @IsAadhaarVerified, @IsContactNumberVerified, @AdditionalNotes";
            var id = await _dbConnection.QuerySingleAsync<int>(sql, rider);
            rider.RiderID = id;
            return rider;
        }

        public async Task<Rider> UpdateRiderAsync(int id, Rider rider)
        {
            var sql = @"EXEC spUpdateRider @RiderID, @VendorID, @ReferenceName, @RiderName, @Gender, @DateOfBirth, @AadharCardNumber, @PANNumber, @BloodGroup, @ContactNumber, @EmailID, @AlternativeContactNumber, @AlternativeEmail, @EmergencyContactName, @EmergencyContactRelation, @EmergencyContactPersonID, @EmergencyContactNumber, @AddressLine1, @AddressLine2, @State, @City, @Zip, @Landmark, @HighestDegreeEarned, @PreviousOrgName, @AccountNumber, @BankName, @IFSCCode, @UANNumber, @InsurancePolicyNumber, @InsurerName, @InsuranceStartDate, @InsuranceEndDate, @FamilyMemberName, @FamilyMemberRelation, @FamilyMemberIDType, @FamilyMemberID, @FamilyMemberContact, @IsBackgroundVerificationCompleted, @IsPhysicalVerificationCompleted, @BackgroundVerificationAgencyName, @IsAadhaarVerified, @IsContactNumberVerified, @AdditionalNotes";
            await _dbConnection.ExecuteAsync(sql, rider);
            return rider;
        }

        public async Task<bool> DeleteRiderAsync(int id)
        {
            var sql = "EXEC spDeleteRider @RiderID";
            var affectedRows = await _dbConnection.ExecuteAsync(sql, new { RiderID = id });
            return affectedRows > 0;
        }
    }
}
