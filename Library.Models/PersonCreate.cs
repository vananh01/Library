using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class PersonCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a valid name")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a valid Email")]
        public string Email { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a valid password")]
        public string Password { get; set; }
    }
}
