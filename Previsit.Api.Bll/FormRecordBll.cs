using Previsit.Api.Bll.Interface;
using Previsit.Api.Dal.Repository.Interface;
using Previsit.Api.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Previsit.Api.Bll
{
    public class FormRecordBll : IFormRecordBll
    {
        private readonly IFormRecordRepository _formRecordRepository;
        public FormRecordBll(IFormRecordRepository formRecordRepository)
        {
            _formRecordRepository = formRecordRepository;
        }
        public async Task<int> UpdateForm(FormRecord formRecord)
        {
            return await _formRecordRepository.UpdateFormRecord(formRecord);
        }

        public async Task<FormRecord> GetFormRecord(int formId)
        {
            return await _formRecordRepository.GetFormRecordByFormId(formId);
        }

        public async Task<int> AddFormRecord(FormRecord formRecord)
        {
            return await _formRecordRepository.AddFormRecord(formRecord);
        }
    }
}
