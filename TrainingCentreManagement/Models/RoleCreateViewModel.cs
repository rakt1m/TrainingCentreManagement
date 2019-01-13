using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingCentreManagement.Models
{
    public class RoleCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string NormalizedName { get; set; }
        [Required]
        public string ConcurrencyStamp { get; set; }    
    }
}
