using Previsit.Api.Model.Models;
using System.Threading.Tasks;

namespace Previsit.Api.Bll.Interface
{
    public interface IPatientAccountInfoBll
    {
        Task<int> UpdatePatientAccountInfoBll(PatientAccountInfo patientAccountInfo);

        Task<PatientAccountInfo> GetPatientAccountInfoByVisitCardIdBll(int visitCardId);

        //验证是否存在就诊卡号和姓名
        Task<PatientAccountInfo> LoginCheck(int visitCardId, string name);
    }
}
