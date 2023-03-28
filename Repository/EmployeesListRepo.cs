using HRM_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Repository
{
    public class EmployeesListRepo : IEmployeesListRepo<EmployeesList>
    {
        private readonly HRM_DB_ProjectContext db;
        public EmployeesListRepo(HRM_DB_ProjectContext _db)
        {
            db = _db;
        }

        public async Task<EmployeesList> add_Employee(EmployeesList employee)
        {
            try
            {
                db.EmployeesLists.AddAsync(employee);
                await db.SaveChangesAsync();
                return employee;
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<EmployeesList> fire_Employee(EmployeesList employee)
        {
            try
            {
                db.EmployeesLists.Remove(employee);
                await db.SaveChangesAsync();
                return employee;
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<EmployeesList>> getAll_Employees(string location_id)
        {
            try
            {
                return await db.EmployeesLists.Where(x => x.LocationId == location_id).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<EmployeesList> get_Employee(int id)
        {
            try
            {
                return await db.EmployeesLists.FirstOrDefaultAsync(x => x.EmployeeId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<EmployeesList> update_Employee(EmployeesList employee)
        {
            try
            {
                db.EmployeesLists.Update(employee);
                await db.SaveChangesAsync();
                return employee;
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
