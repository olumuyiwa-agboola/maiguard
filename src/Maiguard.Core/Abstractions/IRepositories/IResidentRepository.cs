using Maiguard.Core.Models.Residents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Abstractions.IRepositories
{
    public interface IResidentRepository
    {
        public int InsertNewResident(NewResident newResident, string residentId);
    }
}
