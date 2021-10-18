using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService
    {
        private readonly Guid _userId;
        public BookService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    OwnerId = _userId,
                    BookName = model.BookName,
                    BookDescription = model.BookDescription,
                    Genre = model.Genre
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Books
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new BookListItem
                            {
                                BookID = e.BookID,
                                BookName = e.BookName
                            }
                        );
                return query.ToArray();
            }
        }

        public BookDetail GetBookById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookID == id && e.OwnerId == _userId);
                return
                    new BookDetail
                    {
                        BookID = entity.BookID,
                        BookName = entity.BookName,
                        BookDescription = entity.BookDescription,
                        Genre = entity.Genre
                    };
            }
        }

        public bool UpdateBook(BookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookID == model.BookID && e.OwnerId == _userId);

                entity.BookName = model.BookName;
                entity.BookDescription = model.BookDescription;
                entity.Genre = model.Genre;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBook(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Books
                    .Single(e => e.BookID == bookId && e.OwnerId == _userId);

                ctx.Books.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
