using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Previsit.Api.Model.Models
{
    [Table("form_record", Schema = "public")]
    public class FormRecord
    {
        [Column("form_id"), Key]
        public int FormId { get; set; }

        [Column("visit_id")]
        public int VisitId { get; set; }

        /// <summary>
        /// 主诉
        /// </summary>
        [Column("chief_complaint")]
        public string ChiefComplaint { get; set; }

        /// <summary>
        /// 现病史
        /// </summary>
        [Column("present_illness")]
        public string PresentIllness { get; set; }

        /// <summary>
        /// 现病史
        /// </summary>
        [Column("history_illness")]
        public string HistoryIllness { get; set; }

        /// <summary>
        /// 个人史
        /// </summary>
        [Column("present_illness")]
        public string PersonalIllness { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        [Column("department")]
        public string Department { get; set; }

        /// <summary>
        /// 患者是否需要科室分配帮助
        /// </summary>
        [Column("is_need_disribute")]
        public string IsDisribute { get; set; }
    }
}
