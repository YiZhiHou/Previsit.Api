using Previsit.Api.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Previsit.Api.Bll.Interface
{
    public interface IFormRecordBll
    {
        Task<int> UpdateForm(FormRecord formRecord);

        Task<FormRecord> GetFormRecord(int formId);

        Task<int> AddFormRecord(FormRecord formRecord);
    }
}
