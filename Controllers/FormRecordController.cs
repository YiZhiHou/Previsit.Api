using Microsoft.AspNetCore.Mvc;
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
    public class FormRecordController : Controller
    {
        private readonly IFormRecordBll _formRecordBll;

        public FormRecordController(IFormRecordBll formRecordBll)
        {
            _formRecordBll = formRecordBll;
        }

        [HttpPost("updateForm")]
        public async Task<ResultModel> UpdateForm(FormRecord formRecord)
        {
            var result = await _formRecordBll.UpdateForm(formRecord);
            return PackResultModel.PackResult(result, HttpStatusCode.OK, "预问诊表单更新成功");
        }

        [HttpGet("getForm")]
        public async Task<ResultModel> GetForm(int formId)
        {
            var result = await _formRecordBll.GetFormRecord(formId);
            return PackResultModel.PackResult(result, HttpStatusCode.OK, "表单获取成功");
        }

        [HttpPost("addForm")]
        public async Task<ResultModel> AddForm(FormRecord formRecord)
        {
            var result = await _formRecordBll.AddFormRecord(formRecord);
            return PackResultModel.PackResult(result, HttpStatusCode.OK, "表单添加成功");
        }
    }

}
