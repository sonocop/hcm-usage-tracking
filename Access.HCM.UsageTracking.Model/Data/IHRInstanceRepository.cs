using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Access.HCM.UsageTracking.Model.Data
{
    public interface IHRInstanceRepository
    {
        Task<bool> SaveInstanceRecord(HRInstanceDataModel dataModel);
    }
}
