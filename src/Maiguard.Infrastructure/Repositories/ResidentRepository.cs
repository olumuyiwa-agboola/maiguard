using Dapper;
using Maiguard.Core.Abstractions.IRepositories;
using Maiguard.Core.Models.Residents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Infrastructure.Repositories
{
    public class ResidentRepository(IDbContext _dbContext) : IResidentRepository
    {
        public int InsertNewResident(NewResident newResident, string residentId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("ResidentId", residentId);
            parameters.Add("LastName", newResident.LastName);
            parameters.Add("FirstName", newResident.FirstName);
            parameters.Add("PhoneNumber", newResident.PhoneNumber);
            parameters.Add("OnboardedBy", newResident.OnboardedBy);
            parameters.Add("CommunityId", newResident.CommunityId);
            parameters.Add("EmailAddress", newResident.EmailAddress);
            parameters.Add("RelativeAddress", newResident.RelativeAddress);
            parameters.Add("RecordLastUpdatedBy", newResident.OnboardedBy);
            parameters.Add("IsActiveLastUpdatedBy", newResident.OnboardedBy);

            string newResidentInsertStatement = "INSERT INTO Residents " +
                                                "(ResidentId, CommunityId, FirstName, LastName, EmailAddress, PhoneNumber, RelativeAddress, OnboardedBy, IsActiveLastUpdatedBy, RecordLastUpdatedBy)" +
                                                "VALUES (@ResidentId, @CommunityId, @FirstName, @LastName, @EmailAddress, @PhoneNumber, @RelativeAddress, @OnboardedBy, @IsActiveLastUpdatedBy, @RecordLastUpdatedBy)";

            using IDbConnection dbConnection = _dbContext.MaiguardDbConnection();
            int affeectedRows = dbConnection.Execute(newResidentInsertStatement, parameters);
            
            return affeectedRows;
        }
    }
}
