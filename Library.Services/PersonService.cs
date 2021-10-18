using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class PersonService
    {
        private readonly Guid _userId;
        public PersonService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePerson(PersonCreate model)
        {
            var entity =
                new Person()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Password = model.Password,
                    Email = model.Email
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.People.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PersonListItem> GetPeople()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .People
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PersonListItem
                                {
                                    PersonID = e.PersonID,
                                    Name = e.Name,
                                    Email = e.Email
                                }
                            );
                return query.ToArray();
            }
        }

        public PersonDetail GetPersonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .People
                        .Single(e => e.PersonID == id && e.OwnerId == _userId);
                return
                    new PersonDetail
                    {
                        PersonID = entity.PersonID,
                        Name = entity.Name,
                        Password = entity.Password,
                        Email = entity.Email
                    };
            }
        }

        public bool UpdatePerson (PersonEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .People
                        .Single(e => e.PersonID == model.PersonID && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Password = model.Password;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePerson(int personId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .People
                        .Single(e => e.PersonID == personId && e.OwnerId == _userId);
                ctx.People.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
