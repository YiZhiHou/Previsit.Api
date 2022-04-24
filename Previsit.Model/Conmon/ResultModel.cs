using Newtonsoft.Json;
using System.Net;

namespace Previsit.Api.Model.Conmon
{
    public class ResultModel
    {
        /// <summary>
        /// 消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("status")]
        public HttpStatusCode Status { get; set; }

        /// <summary>
        /// 数据主体
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; }

        /// <summary>
        /// 数据总数
        /// </summary>
        //[JsonProperty("totalCount")]
        //public int TotalCount { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
