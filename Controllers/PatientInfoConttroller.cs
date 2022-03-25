


using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Previsit.Api.Controllers
{
    [Route("api/patientinformation")]
    [ApiController]
    public class PatientInfoConttroller : Controller
    {
        /// <summary>
        /// 更改患者信息
        /// </summary>
        /// <param name="patientinfo"></param>
        /// <returns></returns>
        [HttpPost("updatepatientinfo")]
        public async Task<bool> UpdatePatientInformation(string patientinfo)
        {
            
            return true;
        }

        /// <summary>
        /// 获取患者信息
        /// </summary>
        /// <param name="patientid"></param>
        /// <returns></returns>
        [HttpGet("getpatientinfo")]
        public async Task<bool> GetPatientInformation(string patientid)
        {
            
            return true;
        }
    }
}
