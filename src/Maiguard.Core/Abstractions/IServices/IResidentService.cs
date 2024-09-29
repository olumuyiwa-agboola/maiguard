using Maiguard.Core.Models.APIResponseModels;
using Maiguard.Core.Models.Residents;

namespace Maiguard.Core.Abstractions.IServices
{
    public interface IResidentService
    {
        public Task<ApiResponseWithStatusCode> SignUpResident(NewResident newResident);

        public Task<string> ActivateResident(NewResident newResident);

        public Task<string> DeactivateResident(NewResident newResident);
    }
}
