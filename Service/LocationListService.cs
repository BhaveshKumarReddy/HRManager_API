using HRM_API.Models;
using HRM_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Service
{
    public class LocationListService : ILocationListService<LocationList>
    {
        private readonly ILocationListRepo<LocationList> repo;
        public LocationListService(ILocationListRepo<LocationList> _repo)
        {
            repo = _repo;
        }
        public async Task<List<LocationList>> getAll_Locations()
        {
            try
            {
                return await repo.getAll_Locations();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
