using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.HCM.UsageTracking.Model.Logic;
using Access.HCM.UsageTracking.Model.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Access.HCM.UsageTracking.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HRInstancesController : ControllerBase
    {
        private readonly IHRInstanceLogic _hRInstanceLogic;
        public HRInstancesController(IHRInstanceLogic hRInstanceLogic) {
            _hRInstanceLogic = hRInstanceLogic;
        }
        // POST: api/v1/HRInstances
        [HttpPost]
        public void Post([FromBody] HRInstanceViewModel instance)
        {
            _hRInstanceLogic.SaveInstanceRecord(instance);
        }
    }
}
