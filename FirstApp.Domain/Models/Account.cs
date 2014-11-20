namespace FirstApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public int ID { get; set; }

        [Required]
        [StringLength(32)]
        public string AccountName { get; set; }

        [StringLength(128)]
        public string AccountNotes { get; set; }
    }
}
