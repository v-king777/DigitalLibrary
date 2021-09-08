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
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public List<Book> FindAll()
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
                return db.Books.FirstOrDefault(x => x.Id == id);
            }
        }

        public void UpdateById(int id, Book book)
        {
            using (var db = new AppContext())
            {
                var updated = db.Books.FirstOrDefault(x => x.Id == id);

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
                var deleted = db.Books.FirstOrDefault(x => x.Id == id);

                db.Books.Remove(deleted);
                db.SaveChanges();
            }
        }

        public void HandOverById(int bookId, int userId)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(x => x.Id == bookId);
                var user = db.Users.FirstOrDefault(x => x.Id == userId);

                book.UserId = user.Id;

                db.SaveChanges();
            }
        }

        public void ReturnById(int id)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(x => x.Id == id);
                book.UserId = null;
                db.SaveChanges();
            }
        }

        public bool IsExist(int id)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(x => x.Id == id);
                return book.UserId != null;
            }
        }

        public List<Book> FindByGenreAndYear(string genre, int year1, int year2)
        {
            using (var db = new AppContext())
            {
                return db.Books
                    .Where(x => x.Genre.Contains(genre) && x.Year >= year1 && x.Year <= year2)
                    .ToList();
            }
        }

        public Book FindLastYear()
        {
            using (var db = new AppContext())
            {
                return db.Books.FirstOrDefault(x => x.Year == db.Books.Max(x => x.Year));
            }
        }

        public int CountByAuthor(string author)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(x => x.Author == author).ToList().Count();
            }
        }

        public int CountByGenre(string genre)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(x => x.Genre == genre).ToList().Count();
            }
        }
    }

    public interface IBookRepository
    {
        void Create(Book book);

        List<Book> FindAll();

        Book FindById(int id);

        void UpdateById(int id, Book book);

        void DeleteById(int id);

        void HandOverById(int bookId, int userId);

        void ReturnById(int id);

        bool IsExist(int id);

        List<Book> FindByGenreAndYear(string genre, int year1, int year2);

        Book FindLastYear();

        int CountByAuthor(string author);

        int CountByGenre(string genre);
    }
}
