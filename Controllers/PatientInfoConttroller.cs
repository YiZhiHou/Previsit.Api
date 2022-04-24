using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Previsit.Api.Bll.Conmon;
using Previsit.Api.Bll.Interface;
using Previsit.Api.Model.Conmon;
using Previsit.Api.Model.Models;
using System.Net;
using System.Threading.Tasks;

namespace Previsit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInfoConttroller : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPatientInfoBll _patientInfoBll;
        public PatientInfoConttroller(IConfiguration configuration, IPatientInfoBll patientInfoBll)
        {
            _configuration = configuration;
            _patientInfoBll = patientInfoBll;
        }


        /// <summary>
        /// 更改患者信息
        /// </summary>
        /// <param name="patientinfo"></param>
        /// <returns></returns>
        [HttpPost("updatepatientinfo")]
        public async Task<ResultModel> UpdatePatientInformation(PatientInfo patientinfo)
        {
            var result = await _patientInfoBll.UpdatePatientInfoBll(patientinfo);
            //_logger.LogInformation($"更改患者信息，患者Id为:{patientinfo.PatientId}");
            return PackResultModel.PackResult(result, HttpStatusCode.OK, "信息更新成功");
        }

        /// <summary>
        /// 获取患者信息
        /// </summary>
        /// <param name="visit_card_id"></param>
        /// <returns></returns>
        [HttpGet("getpatientinfo")]
        public async Task<ResultModel> GetPatientInformation(int visit_card_id)
        {
            var result = await _patientInfoBll.GetPatientInfoByVisitCardIdBll(visit_card_id);
                if(result == null)
                {
                return PackResultModel.PackResult(result, HttpStatusCode.NotFound, "未查找到该id");
            }
            //_logger.LogInformation($"获取患者信息，患者Id为:{visit_card_id}");
            return PackResultModel.PackResult(result, HttpStatusCode.OK, "信息获取成功");
        }
    }
}
