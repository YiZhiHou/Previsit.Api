using Previsit.Api.Model.Models;
using System.Threading.Tasks;

namespace Previsit.Api.Bll.Interface
{
    public interface IPatientInfoBll
    {
        Task<int> UpdatePatientInfoBll(PatientInfo patientInfo);

        Task<PatientInfo> GetPatientInfoByVisitCardIdBll(int visitCardId);
    }
}
