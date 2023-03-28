using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API.Service
{
    public interface IHrListService<HrList>
    {
        Task<List<HrList>> getAll_HRs();
        Task<HrList> get_HR(string email);
        Task<HrList> add_HR(HrList hr);
        Task<HrList> edit_HR(HrList hr);
    }
}
