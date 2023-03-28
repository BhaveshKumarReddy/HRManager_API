using HRM_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Repository
{
    public class LocationListRepo : ILocationListRepo<LocationList>
    {
        private readonly HRM_DB_ProjectContext db;
        public LocationListRepo(HRM_DB_ProjectContext _db)
        {
            db = _db;
        }
        public async Task<List<LocationList>> getAll_Locations()
        {
            try
            {
                return db.LocationLists.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
