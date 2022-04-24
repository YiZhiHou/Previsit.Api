using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Previsit.Api.Model.Models
{
    [Table("patient_info", Schema = "public")]
    public class PatientInfo
    {
        [Column("visit_card_id"), Key]
        public int VisitCardId { get; set; }

        [Column("visit_id")]
        public int VisitId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("sex")]
        public string Sex { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("id_card")]
        public string IdCard { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

    }
}
