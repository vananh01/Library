using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class LibraryyService
    {
        private readonly Guid _userId;
        public LibraryyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLibraryy(LibraryyCreate model)
        {
            var entity =
                new Libraryy()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Address = model.Address,
                };
           using (var ctx = new ApplicationDbContext())
            {
                ctx.Libraries.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LibraryyListItem> GetLibraries()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Libraries
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new LibraryyListItem
                            {
                                LibraryID = e.LibraryID,
                                Name = e.Name,
                                Address = e.Address
                            }
                        );
                return query.ToArray();
            }
        }
    }
}
