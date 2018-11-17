using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Access.HCM.UsageTracking.Model.Data
{
    public interface IHRInstanceRepository
    {
        void SaveInstanceRecord(HRInstanceDataModel dataModel);
    }
}
