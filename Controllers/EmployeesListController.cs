using HRM_API.Models;
using HRM_API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesListController : Controller
    {
        private readonly IEmployeeListService<EmployeesList> service;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(EmployeesListController));
        public EmployeesListController(IEmployeeListService<EmployeesList> _service)
        {
            service = _service;
        }

        [HttpGet("{location_id}")]
        public async Task<ActionResult<List<EmployeesList>>> display_Employees(string location_id)
        {
            _log4net.Info("Fetching all employees working in location id: "+ location_id);
            try
            {
                return await service.getAll_Employees(location_id);
            }
            catch (Exception e)
            {
                _log4net.Error("Fetching all employees ERROR ");
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getEmployeeByID/{employee_id}")]
        public async Task<ActionResult<EmployeesList>> get_Employee(int employee_id)
        {
            _log4net.Info("Fetching an employee by id: " + employee_id);
            try
            {
                return await service.get_Employee(employee_id);
            }
            catch (Exception e)
            {
                _log4net.Error("Fetching an employee ERROR ");
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> add_Employee(EmployeesList employee)
        {
            _log4net.Info("Adding a new employee "+employee.EmployeeName);
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model is not valid");
                }
                await service.add_Employee(employee);
                return Ok();
            }
            catch (Exception e)
            {
                _log4net.Error("Adding a new employee ERROR ");
                return BadRequest("Adding a new employee ERROR ");
            }
        }


        [HttpPut("edit_Employee/")]
        public async Task<ActionResult> edit_Employee(EmployeesList employee)
        {
            _log4net.Info("Editing the information of "+ employee.EmployeeName);
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model is not valid");
                }
                await service.edit_Employee(employee);
                return Ok();
            }
            catch (Exception e)
            {
                _log4net.Error("Editing information ERROR ");
                return BadRequest(e.Message);
            }
        }

        [HttpPut("increment_Salary/id/")]
        public async Task<ActionResult<EmployeesList>> increment_Salary(Object employees)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model is not valid");
                }
                var obj = employees.ToString();
                var employee = JsonConvert.DeserializeObject<EmployeesList>(obj);
                _log4net.Info("Incrementing the salary of " + employee.EmployeeName);
                await service.increment_Salary(employee.EmployeeId,employee.EmployeeSalary);
                return Ok();
            }
            catch (Exception e)
            {
                _log4net.Error("Increment Salary ERROR ");
                return BadRequest(e.Message);
            }
        }

        [HttpPut("transfer_Employee/{id}/{location}")]
        public async Task<ActionResult<EmployeesList>> transfer_Employee(int id, string location, Object employees)
        {
            _log4net.Info("Transferring employee "+id+" to location "+location);
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model is not valid");
                }
                await service.transfer_Employee(id,location);
                return Ok();
            }
            catch (Exception e)
            {
                _log4net.Error("Transferring employee ERROR ");
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("fire_Employee/{id}")]
        public async Task<ActionResult> fire_Employee(int id)
        {
            _log4net.Info("Firing an employee "+id);
            try
            {
                await service.fire_Employee(id);
                return Ok();
            }
            catch (Exception e)
            {
                _log4net.Error("Fire Employee ERROR ");
                return BadRequest(e.Message);
            }
        }
    }
}
