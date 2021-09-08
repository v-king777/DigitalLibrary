using System.Collections.Generic;
using System.Linq;

namespace DigitalLibrary
{
    class UserRepository : IUserRepository
    {
        public void Create(User user)
        {
            using (var db = new AppContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public List<User> FindAll()
        {
            using (var db = new AppContext())
            {
                return db.Users.OrderBy(x => x.Name).ToList();
            }
        }

        public User FindById(int id)
        {
            using (var db = new AppContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == id);
            }
        }

        public User FindByEmail(string email)
        {
            using (var db = new AppContext())
            {
                return db.Users.FirstOrDefault(x => x.Email == email);
            }
        }
        
        public void UpdateById(int id, User user)
        {
            using (var db = new AppContext())
            {
                var updated = db.Users.FirstOrDefault(x => x.Id == id);

                updated.Name = user.Name;
                updated.Email = user.Email;

                db.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            using (var db = new AppContext())
            {
                var deleted = db.Users.FirstOrDefault(x => x.Id == id);

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

        List<User> FindAll();

        User FindById(int id);

        User FindByEmail(string email);

        void UpdateById(int id, User user);

        void DeleteById(int id);

        int CountBooksById(int id);
    }
}
