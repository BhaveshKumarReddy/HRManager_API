using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Repository
{
    public interface ILocationListRepo<LocationList>
    {
        Task<List<LocationList>> getAll_Locations();
    }
}
