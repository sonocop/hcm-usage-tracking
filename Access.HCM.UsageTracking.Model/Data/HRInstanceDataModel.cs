using System;
using System.Collections.Generic;
using System.Text;

namespace Access.HCM.UsageTracking.Model.Data
{
    public class HRInstanceDataModel
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public Guid LicenseGuid { get; set; }
        public int VersionMajor { get; set; }
        public int VersionMinor { get; set; }
        public int VersionRevision { get; set; }
        public int VersionBuild { get; set; }
        public bool LikelyTestSystem { get; set; }
        public Guid LastSSURunGuid { get; set; }
        public DateTime LastAuditDate { get; set; }
        public DateTime LatestLoggedInDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
