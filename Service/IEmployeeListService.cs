using HRM_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Service
{
    public interface IEmployeeListService<EmployeesList>
    {
        Task<List<EmployeesList>> getAll_Employees(string location_id);
        Task<EmployeesList> get_Employee(int id);
        Task<EmployeesList> add_Employee(EmployeesList employee);
        Task<EmployeesList> edit_Employee(EmployeesList employee);
        Task<EmployeesList> increment_Salary(int id,decimal? salary);
        Task<EmployeesList> transfer_Employee(int id,string location);
        Task<EmployeesList> fire_Employee(int id);
    }
}
