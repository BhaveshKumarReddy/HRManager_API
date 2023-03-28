using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Service
{
    public interface ILocationListService<LocationList>
    {
        Task<List<LocationList>>  getAll_Locations();
    }
}
