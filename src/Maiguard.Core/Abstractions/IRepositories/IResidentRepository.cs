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
        /// Executes the data access and persistence logic for 
        /// saving a new resident's information to the database
        /// </summary>
        /// <param name="request"></param>
        /// <param name="residentId"></param>
        /// <returns>int</returns>
        public int AddResident(ResidentRegistrationRequest request, string residentId);

        /// <summary>
        /// Executes the data access and persistence logic for acitvating a resident's account
        /// </summary>
        /// <param name="request"></param>
        /// <returns>int</returns>
        public int ActivateResident(ResidentActivationRequest request);

        /// <summary>
        /// Executes the data access and persistence logic for deacitvating a resident's account
        /// </summary>
        /// <param name="request"></param>
        /// <returns>int</returns>
        public int DeactivateResident(ResidentDeactivationRequest request);
    }
}
