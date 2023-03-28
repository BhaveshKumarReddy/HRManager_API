using HRM_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Repository
{
    public class HrListRepo : IHrListRepo<HrList>
    {
        private readonly HRM_DB_ProjectContext db;
        public HrListRepo(HRM_DB_ProjectContext _db)
        {
            db = _db;
        }
        public async Task<HrList> add_HR(HrList hr)
        {
            try
            {
                await db.HrLists.AddAsync(hr);
                await db.SaveChangesAsync();
                return await get_HR(hr.HrEmail);
            }
            catch(DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<HrList> edit_HR(HrList hr)
        {
            try
            {
                db.HrLists.Update(hr);
                await db.SaveChangesAsync();
                return await get_HR(hr.HrEmail);
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

        public async Task<List<HrList>> getAll_HRs()
        {
            try
            {
                return db.HrLists.Include(x => x.Location).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<HrList> get_HR(string email)
        {
            try
            {
                return await db.HrLists.FirstOrDefaultAsync(x => x.HrEmail == email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
