using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Previsit.Api.Model.Models
{
    [Table("doctor_account_info", Schema = "public")]
    public class DoctorAccountInfo
    {
        [Column("doctor_id"), Key]
        public int DoucorId { get; set; }

        [Column("password")]
        public string Password { get; set; }

    }
}
