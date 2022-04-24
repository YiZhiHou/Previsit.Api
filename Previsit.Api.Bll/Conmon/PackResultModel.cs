using Previsit.Api.Model.Conmon;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Previsit.Api.Bll.Conmon
{
    public class PackResultModel
    {
        public static ResultModel PackResult(object value, HttpStatusCode status, string msg)
        {
            return new ResultModel()
            {
                Data = value,
                Status = status,
                Success = true,
                Message = msg
            };
        }
    }
}
