using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Repository
{
    public interface IEmployeesListRepo<EmployeesList>
    {
        Task<List<EmployeesList>> getAll_Employees(string location_id);
        Task<EmployeesList> get_Employee(int id);
        Task<EmployeesList> add_Employee(EmployeesList employee);
        Task<EmployeesList> update_Employee(EmployeesList employee);
        Task<EmployeesList> fire_Employee(EmployeesList employee);
    }
}
