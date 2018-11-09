using Access.HCM.UsageTracking.Model.Data;
using Access.HCM.UsageTracking.Model.Logic;
using Access.HCM.UsageTracking.Model.View;
using System;
using System.Threading.Tasks;

namespace Access.HCM.UsageTracking.Logic
{
    public class HRInstanceLogic : IHRInstanceLogic
    {
        private readonly IHRInstanceRepository _hRInstanceRepository;
        public HRInstanceLogic(IHRInstanceRepository hRInstanceRepository) {
            _hRInstanceRepository = hRInstanceRepository;
        }
        public async Task<bool> SaveInstanceRecord(HRInstanceViewModel instance)
        {
            await _hRInstanceRepository.SaveInstanceRecord(new HRInstanceDataModel()
            {
                Identifier = instance.Identifier,
                LicenseGuid = instance.LicenseGuid,
                VersionMajor = instance.VersionMajor,
                VersionMinor = instance.VersionMinor,
                VersionRevision = instance.VersionRevision,
                VersionBuild = instance.VersionBuild,
                LikelyTestSystem = instance.LikelyTestSystem,
                LastSSURunGuid = instance.LastSSURunGuid,
                LastAuditDate = instance.LastAuditDate,
                LatestLoggedInDate = instance.LatestLoggedInDate
            });
            return true;
        }
    }
}
