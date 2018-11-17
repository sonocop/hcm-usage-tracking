using Access.HCM.UsageTracking.Model.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Access.HCM.UsageTracking.Model.Logic
{
    public interface IHRInstanceLogic
    {
        void SaveInstanceRecord(HRInstanceViewModel instance);
    }
}
