using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Previsit.Api.Model.Models
{
    [Table("patient_account_info", Schema = "public")]
    public class PatientAccountInfo
    {

        [Column("visit_card_id"), Key]
        public int VisitCardId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("result_flag")]
        public int ResultFlag { get; set; }


    }
}
