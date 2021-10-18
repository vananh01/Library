using Library.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookEdit
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string BookDescription { get; set; }
        [Required]
        public Genre Genre { get; set; }
    }
}
