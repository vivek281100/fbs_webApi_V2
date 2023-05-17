using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace fbs_webApi_v2.DataModels
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Admin_Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Email_Id { get; set; } = string.Empty;

    }
}
