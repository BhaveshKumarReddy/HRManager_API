using HRM_API.Models;
using HRM_API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationListController : Controller
    {
        private readonly ILocationListService<LocationList> service;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LocationListController));
        public LocationListController(ILocationListService<LocationList> _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationList>>> All_locations()
        {
            try
            {
                _log4net.Info("Fetching all locations ");
                return await service.getAll_Locations();
            }
            catch (Exception e)
            {
                _log4net.Error("Fetching locations");
                return BadRequest(e.Message);
            }
        }
    }
}
