using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
    public class PatientAccountInfoConttroller : Controller
    {
        private readonly IConfiguration _configuration;
        private ILogger<PatientAccountInfoConttroller> _logger;
        private readonly IPatientAccountInfoBll _patientAccountInfoBll;
        public PatientAccountInfoConttroller(IConfiguration configuration, ILogger<PatientAccountInfoConttroller> logger, IPatientAccountInfoBll patientAccountInfoBll)
        {
            _logger = logger;
            _configuration = configuration;
            _patientAccountInfoBll = patientAccountInfoBll;
        }


        /// <summary>
        /// 更改患者账号信息
        /// </summary>
        /// <param name="patientAccountInfo"></param>
        /// <returns></returns>
        [HttpPost("UpdatepPatientAccountInfo")]
        public async Task<ResultModel> UpdatePatientAccountInfo(PatientAccountInfo patientAccountInfo)
        {
            var result = await _patientAccountInfoBll.UpdatePatientAccountInfoBll(patientAccountInfo);
            //_logger.LogInformation($"更改患者信息，患者Id为:{patientinfo.PatientId}");
            return PackResultModel.PackResult(result, HttpStatusCode.OK, "信息更新成功");
        }

        /// <summary>
        /// 获取患者账号信息
        /// </summary>
        /// <param name="visitCardId"></param>
        /// <returns></returns>
        [HttpGet("GetPatientAccountInfo")]
        public async Task<ResultModel> GetPatientAccountInfo(int visitCardId)
        {
            var result = await _patientAccountInfoBll.GetPatientAccountInfoByVisitCardIdBll(visitCardId);
            //_logger.LogInformation($"获取患者信息，患者Id为:{visit_card_id}");
            return PackResultModel.PackResult(result, HttpStatusCode.OK, "信息获取成功");
        }


        /// <summary>
        /// 验证卡号与姓名登录
        /// return 0 -------姓名和卡号都存在且正确，进入首页
        /// return 1 -------卡号存在，姓名不正确
        /// return 2 -------姓名存在，卡号不正确
        /// return 3 -------卡号和姓名都不存在
        /// </summary>
        /// <param name="cardno"></param>
        /// <param name="patientname"></param>
        /// <returns></returns>
        [HttpGet("checklogin")]
        public async Task<ResultModel> PaientLogin(int visitCardId, string name)
        {
            var result = await _patientAccountInfoBll.LoginCheck(visitCardId, name);
            if (result.ResultFlag == 0)
            {
                _logger.LogInformation($"患者登录成功，就诊卡号为：{visitCardId}，患者姓名为：{name}");
                return PackResultModel.PackResult(result, HttpStatusCode.OK, "卡号姓名匹配，登录成功");
            }
            else if (result.ResultFlag == 1)
            {
                _logger.LogInformation($"患者登录失败");
                return PackResultModel.PackResult(result, HttpStatusCode.NotFound, "姓名不匹配");
            }
            else if (result.ResultFlag == 2)
            {
                _logger.LogInformation($"患者登录失败");
                return PackResultModel.PackResult(result, HttpStatusCode.NotFound, "卡号不匹配");
            }
            else
            {
                _logger.LogInformation($"患者登录失败");
                return PackResultModel.PackResult(result, HttpStatusCode.NotFound, "卡号姓名不存在");
            }



        }
    }
}
