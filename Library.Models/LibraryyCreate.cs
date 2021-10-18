using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class LibraryyCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a valid name")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a valid Address")]
        public string Address { get; set; }

    }
}
