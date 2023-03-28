using HRM_API.Models;
using HRM_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Service
{
    public class EmployeesListService:IEmployeeListService<EmployeesList>
    {
        private readonly IEmployeesListRepo<EmployeesList> repo;
        public EmployeesListService(IEmployeesListRepo<EmployeesList> _repo)
        {
            repo = _repo;
        }

        public async Task<EmployeesList> add_Employee(EmployeesList employee)
        {
            await repo.add_Employee(employee);
            return employee;
        }

        public async Task<List<EmployeesList>> getAll_Employees(string location_id)
        {
            return await repo.getAll_Employees(location_id);
        }

        public async Task<EmployeesList> get_Employee(int id)
        {
            return await repo.get_Employee(id);
        }

        public async Task<EmployeesList> edit_Employee(EmployeesList employee)
        {
            await repo.update_Employee(employee);
            return employee;
        }

        public async Task<EmployeesList> increment_Salary(int id, decimal? salary)
        {
            EmployeesList employee = await repo.get_Employee(id);
            employee.EmployeeSalary = salary;
            employee.EmployeeAppraisalDate = DateTime.Today.AddYears(1);
            await repo.update_Employee(employee);
            return employee;
        }

        public async Task<EmployeesList> transfer_Employee(int id,string location)
        {
            EmployeesList employee = await repo.get_Employee(id);
            employee.LocationId = location;
            await repo.update_Employee(employee);
            return employee;
        }
        public async Task<EmployeesList> fire_Employee(int id)
        {
            var employee = await get_Employee(id);
            await repo.fire_Employee(employee);
            return employee;
        }
    }
}
