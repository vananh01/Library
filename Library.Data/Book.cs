using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public enum Genre { YoungAdult, Fantasy, Children, Fiction, NonFiction, Thriller, Romance, Historical }
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string BookDescription { get; set; }
        [Required]
        public Genre Genre { get; set; }
        //[ForeignKey(nameof(LibraryId))]
        //[Display(Name = "Book Location")]
        //public int? LibraryId { get; set; }

    }
}
