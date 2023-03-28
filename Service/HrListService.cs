using HRM_API.Models;
using HRM_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Service
{
    public class HrListService : IHrListService<HrList>
    {
        private readonly IHrListRepo<HrList> repo;
        public HrListService(IHrListRepo<HrList> _repo)
        {
            repo = _repo;
        }
        public async Task<HrList> add_HR(HrList hr)
        {
            return await repo.add_HR(hr);
        }
        public async Task<HrList>  edit_HR(HrList hr)
        {
            return await repo.edit_HR(hr);
        }
        public async Task<List<HrList>> getAll_HRs()
        {
            return await repo .getAll_HRs();
        }
        public async Task<HrList> get_HR(string email)
        {
            return await repo .get_HR(email);
        }
    }
}
