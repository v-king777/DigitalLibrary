using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary
{
    class UserRepository : IUserRepository
    {
        public void Create(User user)
        {
            using (var db = new AppContext())
            {
                db.Database.EnsureCreated();
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public IEnumerable<User> FindAll()
        {
            using (var db = new AppContext())
            {
                return db.Users.ToList();
            }
        }

        public User FindById(int id)
        {
            using (var db = new AppContext())
            {
                return db.Users.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public User FindByEmail(string email)
        {
            using (var db = new AppContext())
            {
                return db.Users.Where(x => x.Email == email).FirstOrDefault();
            }
        }
        
        public void UpdateById(int id, User user)
        {
            using (var db = new AppContext())
            {
                var updated = db.Users.Where(x => x.Id == id).FirstOrDefault();
                updated.Name = user.Name;
                updated.Email = user.Email;
                db.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            using (var db = new AppContext())
            {
                var deleted = db.Users.Where(x => x.Id == id).FirstOrDefault();
                db.Users.Remove(deleted);
                db.SaveChanges();
            }
        }

        public int CountBooksById(int id)
        {
            using (var db = new AppContext())
            {
                return db.Users.Where(x => x.Id == id).Select(x => x.Books.Count).FirstOrDefault();
            }
        }
    }

    public interface IUserRepository
    {
        void Create(User user);

        IEnumerable<User> FindAll();

        User FindById(int id);

        User FindByEmail(string email);

        void UpdateById(int id, User user);

        void DeleteById(int id);

        int CountBooksById(int id);
    }
}
