using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace parking.Models.Domain
{
    public class UserPreference
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(200)]
        public string Set1 { get; set; }
        [MaxLength(200)]
        public string Set2 { get; set; }
        [MaxLength(200)]
        public string Set3 { get; set; }
    }
}