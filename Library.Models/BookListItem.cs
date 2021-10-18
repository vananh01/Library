using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookListItem
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string BookName { get; set; }

    }
}
