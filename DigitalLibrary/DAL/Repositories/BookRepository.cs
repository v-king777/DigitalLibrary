using System.Collections.Generic;
using System.Linq;

namespace DigitalLibrary
{
    class BookRepository : IBookRepository
    {
        public void Create(Book book)
        {
            using (var db = new AppContext())
            {
                db.Database.EnsureCreated();
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public IEnumerable<Book> FindAll()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderBy(x => x.Title).ToList();
            }
        }

        public Book FindById(int id)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public void UpdateById(int id, Book book)
        {
            using (var db = new AppContext())
            {
                var updated = db.Books.Where(x => x.Id == id).FirstOrDefault();
                updated.Title = book.Title;
                updated.Author = book.Author;
                updated.Year = book.Year;
                updated.Genre = book.Genre;
                db.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            using (var db = new AppContext())
            {
                var deleted = db.Books.Where(x => x.Id == id).FirstOrDefault();
                db.Books.Remove(deleted);
                db.SaveChanges();
            }
        }

        public void HandOverById(int bookId, int userId)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(x => x.Id == bookId).FirstOrDefault();
                var user = db.Users.Where(x => x.Id == userId).FirstOrDefault();
                book.UserId = user.Id;
                db.SaveChanges();
            }
        }

        public void ReturnById(int id)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(x => x.Id == id).FirstOrDefault();
                book.UserId = null;
                db.SaveChanges();
            }
        }

        public bool IsExist(int id)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(x => x.Id == id).FirstOrDefault();
                return book.UserId != null;
            }
        }

        public IEnumerable<Book> FindByGenreAndYear(string genre, int year1, int year2)
        {
            using (var db = new AppContext())
            {
                return db.Books
                    .Where(x => x.Genre.Contains(genre) && x.Year >= year1 && x.Year <= year2)
                    .ToList();
            }
        }
    }

    public interface IBookRepository
    {
        void Create(Book book);

        IEnumerable<Book> FindAll();

        Book FindById(int id);

        void UpdateById(int id, Book book);

        void DeleteById(int id);

        void HandOverById(int bookId, int userId);

        void ReturnById(int id);

        bool IsExist(int id);

        IEnumerable<Book> FindByGenreAndYear(string genre, int year1, int year2);
    }
}
