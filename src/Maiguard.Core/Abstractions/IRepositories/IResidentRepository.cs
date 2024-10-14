using Maiguard.Core.Models.Residents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Abstractions.IRepositories
{
    /// <summary>
    /// Defines the contract for the methods that will execute all the data 
    /// access and persistence logic concerning the accounts of residents
    /// </summary>
    public interface IResidentRepository
    {
        /// <summary>
        /// Executes the business logic for retrieving a resident's information
        /// </summary>
        /// <param name="residentId"></param>
        /// <returns>int</returns>
        public Task<(int, Resident?)> GetResident(string residentId);

        /// <summary>
        /// Executes the data access and persistence logic for 
        /// saving a new resident's information to the database
        /// </summary>
        /// <param name="request"></param>
        /// <param name="residentId"></param>
        /// <returns>int</returns>
        public Task<int> AddResident(ResidentRegistrationRequest request, string residentId);

        /// <summary>
        /// Executes the data access and persistence logic for acitvating a resident's account
        /// </summary>
        /// <param name="request"></param>
        /// <returns>int</returns>
        public Task<int> ActivateResident(ResidentActivationRequest request);

        /// <summary>
        /// Executes the data access and persistence logic for deacitvating a resident's account
        /// </summary>
        /// <param name="request"></param>
        /// <returns>int</returns>
        public Task<int> DeactivateResident(ResidentDeactivationRequest request);

        /// <summary>
        /// Executes the data access logic for validating
        /// a community admin and a potential resident
        /// </summary>
        /// <param name="request"></param>
        /// <returns>int</returns>
        public Task<int> ValidateAdminIdAndResidentEmail(InvitationCodeGenerationRequest request);
    }
}
