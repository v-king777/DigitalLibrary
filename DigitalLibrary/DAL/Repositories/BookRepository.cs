﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void UpdateYearById(int id, string newYear)
        {
            using (var db = new AppContext())
            {
                var updated = db.Books.Where(x => x.Id == id).FirstOrDefault();
                updated.Year = newYear;
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

        public void HandOverBook(int bookId, int userId)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(x => x.Id == bookId).FirstOrDefault();
                var user = db.Users.Where(x => x.Id == userId).FirstOrDefault();
                book.UserId = user.Id;
                db.SaveChanges();
            }
        }

        public void ReturnBook(int bookId)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(x => x.Id == bookId).FirstOrDefault();
                book.UserId = null;
                db.SaveChanges();
            }
        }
    }

    public interface IBookRepository
    {
        void Create(Book book);

        IEnumerable<Book> FindAll();

        Book FindById(int id);

        void UpdateYearById(int id, string newYear);

        void DeleteById(int id);

        void HandOverBook(int bookId, int userId);

        void ReturnBook(int bookId);
    }
}
