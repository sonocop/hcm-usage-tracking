using Access.Data;
using Access.HCM.UsageTracking.Model.Data;
using System;
using System.Threading.Tasks;

namespace Access.HCM.UsageTracking.Data
{
    public class HRInstanceRepository : Model.Data.IHRInstanceRepository
    {
        private readonly IDatabaseProvider _databaseProvider;
        public HRInstanceRepository(IDatabaseProvider databaseProvider) {
            _databaseProvider = databaseProvider;
        }
        public async Task<bool> SaveInstanceRecord(HRInstanceDataModel dataModel)
        {
            await _databaseProvider.CallStoredProcedure("HR", "SaveInstanceRecord", new
                {
                    dataModel.Identifier,
                    dataModel.LicenseGuid,
                    dataModel.VersionMajor,
                    dataModel.VersionMinor,
                    dataModel.VersionRevision,
                    dataModel.VersionBuild,
                    dataModel.LikelyTestSystem,
                    dataModel.LastSSURunGuid,
                    dataModel.LastAuditDate,
                    dataModel.LatestLoggedInDate
                });
            return true;
        }
    }
}
