using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreAsp.Models
{
    public class UserAdditionalnfo
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Image { get; set; }
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}