using Library.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a valid name")]
        public string BookName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a valid description")]
        public string BookDescription { get; set; }
        [Required]
        public Genre Genre { get; set; }
    }

}
