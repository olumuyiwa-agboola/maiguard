using Azure.Core;
using Dapper;
using Maiguard.Core.Abstractions.IRepositories;
using Maiguard.Core.Enums;
using Maiguard.Core.Models.Residents;
using System.Data;

namespace Maiguard.Infrastructure.Repositories
{
    public class ResidentRepository(IDbContext _dbContext) : IResidentRepository
    {
        public async Task<(int, Resident?)> GetResident(string residentId)
        {
            Resident? resident = new();
            (int, Resident?) result = new();
            DynamicParameters parameters = new();

            parameters.Add("ResidentId", residentId);

            string query = @"
                    SELECT r.[ResidentId], r.[FirstName], r.[LastName], r.[EmailAddress], r.[IsVerified] AS VerificationStatus, r.[PhoneNumber], 
                        CAST(DAY(r.[OnboardedAt]) AS VARCHAR(2)) + ' ' + FORMAT(r.[OnboardedAt], 'MMMM, yyyy') AS RegistrationDate, c.[FullName] AS CommunityName, r.[IsActive] AS Status,
		                CONCAT(r.[RelativeAddress], ', ', c.[FullName], ', ', c.[Address], ', ', c.[Location], ', ', c.[LocalGovernmentArea], ' LGA', ', ', c.[State], ' State') AS Address
                    FROM [Maiguard].[dbo].[Residents] r INNER JOIN [Maiguard].[dbo].[Communities] c ON r.[CommunityId] = c.[CommunityId]
                    WHERE r.[ResidentId] = @ResidentId AND r.[IsDeleted] = 0;";

            using (IDbConnection dbConnection = _dbContext.MaiguardDbConnection())
            {
                resident = (await dbConnection.QueryAsync<Resident>(query, parameters)).FirstOrDefault();
            }

            if (resident != null)
            {
                if (resident.Status == "true")
                    resident.Status = "Active";
                else
                    resident.Status = "Inactive";

                if (resident.VerificationStatus == "true")
                    resident.VerificationStatus = "Verified";
                else
                    resident.VerificationStatus = "Not verified";

                result = ((int)DbResponses.Success, resident);
            }
            else
                result = ((int)DbResponses.NoRecordFound, null);

            return result;
        }

        public async Task<int> ActivateResident(ResidentActivationRequest request)
        {
            IEnumerable<int> result;
            DynamicParameters parameters = new();

            parameters.Add("ResidentId", request.ResidentId);
            parameters.Add("Success", (int)DbResponses.Success);
            parameters.Add("IsActiveLastUpdatedBy", request.ActivatedBy);
            parameters.Add("ResidentNotVerified", (int)DbResponses.ResidentNotVerified);
            parameters.Add("ResidentAlreadyActive", (int)DbResponses.ResidentAlreadyActive);

            string query = @"
                    IF EXISTS (SELECT 1 FROM [Maiguard].[dbo].[Residents] WHERE ResidentId = @ResidentId and IsVerified = 0)
	                    BEGIN
		                    SELECT @ResidentNotVerified;
	                    END
                    ELSE IF EXISTS (SELECT 1 FROM [Maiguard].[dbo].[Residents] WHERE ResidentId = @ResidentId and IsActive = 1)
	                    BEGIN
		                    SELECT @ResidentAlreadyActive;
	                    END
                    ELSE
	                    BEGIN
		                    UPDATE [Maiguard].[dbo].[Residents]
		                    SET IsActive = 1
		                    WHERE ResidentId = @ResidentId;

		                    SELECT @Success;
	                    END";

            using (IDbConnection dbConnection = _dbContext.MaiguardDbConnection())
            {
                result = await dbConnection.QueryAsync<int>(query, parameters);
            }

            return result.FirstOrDefault();
        }

        public async Task<int> DeactivateResident(ResidentDeactivationRequest request)
        {
            IEnumerable<int> result;
            DynamicParameters parameters = new();

            parameters.Add("ResidentId", request.ResidentId);
            parameters.Add("Success", (int)DbResponses.Success);
            parameters.Add("IsActiveLastUpdatedBy", request.DeactivatedBy);
            parameters.Add("ResidentNotVerified", (int)DbResponses.ResidentNotVerified);
            parameters.Add("ResidentAlreadyInactive", (int)DbResponses.ResidentAlreadyInactive);

            string query = @"
                    IF EXISTS (SELECT 1 FROM [Maiguard].[dbo].[Residents] WHERE ResidentId = @ResidentId and IsVerified = 0)
	                    BEGIN
		                    SELECT @ResidentNotVerified;
	                    END
                    ELSE IF EXISTS (SELECT 1 FROM [Maiguard].[dbo].[Residents] WHERE ResidentId = @ResidentId and IsActive = 0)
	                    BEGIN
		                    SELECT @ResidentAlreadyInactive;
	                    END
                    ELSE
	                    BEGIN
		                    UPDATE [Maiguard].[dbo].[Residents]
		                    SET IsActive = 0
		                    WHERE ResidentId = @ResidentId;

		                    SELECT @Success;
                        END";

            using (IDbConnection dbConnection = _dbContext.MaiguardDbConnection())
            {
                result = await dbConnection.QueryAsync<int>(query, parameters);
            }

            return result.FirstOrDefault();
        }

        public async Task<int> AddResident(ResidentRegistrationRequest request, string residentId)
        {
            IEnumerable<int> result;
            DynamicParameters parameters = new();

            parameters.Add("ResidentId", residentId);
            parameters.Add("LastName", request.LastName);
            parameters.Add("FirstName", request.FirstName);
            parameters.Add("PhoneNumber", request.PhoneNumber);
            parameters.Add("OnboardedBy", request.OnboardedBy);
            parameters.Add("CommunityId", request.CommunityId);
            parameters.Add("Success", (int)DbResponses.Success);
            parameters.Add("EmailAddress", request.EmailAddress);
            parameters.Add("RelativeAddress", request.RelativeAddress);
            parameters.Add("RecordLastUpdatedBy", request.OnboardedBy);
            parameters.Add("IsActiveLastUpdatedBy", request.OnboardedBy);
            parameters.Add("EmailAlreadyExists", (int)DbResponses.EmailAlreadyExists);
            parameters.Add("ResidentIdAlreadyExists", (int)DbResponses.ResidentIdAlreadyExists);
            parameters.Add("PhoneNumberAlreadyExists", (int)DbResponses.PhoneNumberAlreadyExists);

            string query = @"
                            IF EXISTS (SELECT 1 FROM [Maiguard].[dbo].[Residents] WHERE ResidentId = @ResidentId)
                                BEGIN
                                    SELECT @ResidentIdAlreadyExists;
                                END                        
                            ELSE IF EXISTS (SELECT 1 FROM [Maiguard].[dbo].[Residents] WHERE EmailAddress = @EmailAddress)
                                BEGIN
                                    SELECT @EmailAlreadyExists;
                                END
                            ELSE IF EXISTS (SELECT 1 FROM [Maiguard].[dbo].[Residents] WHERE PhoneNumber = @PhoneNumber)
                                BEGIN
                                    SELECT @PhoneNumberAlreadyExists;
                                END
                            ELSE
                                BEGIN
                                    INSERT INTO [Maiguard].[dbo].[Residents] (ResidentId, CommunityId, FirstName, LastName, EmailAddress, PhoneNumber, RelativeAddress, OnboardedBy, IsActiveLastUpdatedBy, RecordLastUpdatedBy)
                                    VALUES (@ResidentId, @CommunityId, @FirstName, @LastName, @EmailAddress, @PhoneNumber, @RelativeAddress, @OnboardedBy, @IsActiveLastUpdatedBy, @RecordLastUpdatedBy);

                                    SELECT @Success;
                                END";

            using (IDbConnection dbConnection = _dbContext.MaiguardDbConnection())
            {
                result = await dbConnection.QueryAsync<int>(query, parameters);
            }

            return result.FirstOrDefault();
        }

        public async Task<int> ValidateAdminIdAndResidentEmail(InvitationCodeGenerationRequest request)
        {
            IEnumerable<int> result;
            DynamicParameters parameters = new();

            parameters.Add("AdminId", request.AdminId);
            parameters.Add("CommunityId", request.CommunityId);
            parameters.Add("Success", (int)DbResponses.Success);
            parameters.Add("ResidentEmail", request.ResidentEmail);
            parameters.Add("EmailAlreadyExists", (int)DbResponses.EmailAlreadyExists);
            parameters.Add("AdminIdNotValidForCommunity", (int)DbResponses.AdminIdNotValidForCommunity);

            string query = @"
                    IF EXISTS (SELECT 1 FROM [Maiguard].[dbo].[Communities] WHERE AdminId = @AdminId and CommunityId = @CommunityId)
                        BEGIN
		                    IF EXISTS (SELECT 1 FROM [Maiguard].[dbo].[Residents] WHERE EmailAddress = @ResidentEmail)
			                    BEGIN
				                    SELECT @EmailAlreadyExists;
			                    END
		                    ELSE
			                    BEGIN
				                    SELECT @Success;
			                    END
	                    END
                    ELSE
	                    BEGIN
		                    SELECT @AdminIdNotValidForCommunity;
	                    END";

            using (IDbConnection dbConnection = _dbContext.MaiguardDbConnection())
            {
                result = await dbConnection.QueryAsync<int>(query, parameters);
            }

            return result.FirstOrDefault();
        }
    }
}