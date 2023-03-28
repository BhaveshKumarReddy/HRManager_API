using HRM_API.Models;
using HRM_API.Service;
using Microsoft.AspNetCore.Http;
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
    public class HrListController : Controller
    {
        private readonly IHrListService<HrList> service;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HrListController));
        public HrListController(IHrListService<HrList> _service)
        {
            service = _service;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<HrList>> get_HR(string email)
        {
            _log4net.Info("Get HR by "+email+" is invoked");
            try
            {
                var hr = await service.get_HR(email);
                if (hr == null)
                {
                    return NotFound();
                }
                return hr;
            }
            catch (Exception e)
            {
                _log4net.Error("Fetching HR by ID");
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<HrList>> Add_HRs(HrList hr)
        {
            _log4net.Info("Adding new HR: " + hr.HrName);
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model state is not valid");
                }
                return await service.add_HR(hr);
            }
            catch (Exception e)
            {
                _log4net.Error("Adding a new HR");
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<HrList>> edit_HR(HrList hr)
        {
            _log4net.Info("Edit HR by " + hr.HrEmail + " is invoked");
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model state is not valid");
                }
                return await service.edit_HR(hr);
            }
            catch (Exception e)
            {
                _log4net.Error("Editing HR information");
                return BadRequest(e.Message);
            }
        }
    }
}
