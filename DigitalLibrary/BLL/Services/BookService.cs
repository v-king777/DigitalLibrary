using System;
using System.Collections.Generic;

namespace DigitalLibrary
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
            _userRepository = new UserRepository();
        }

        public void AddBook(BookData bookData)
        {
            if (string.IsNullOrEmpty(bookData.Title))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookData.Author))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookData.Year))
                throw new ArgumentNullException();

            if (!int.TryParse(bookData.Year, out int year))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookData.Genre))
                throw new ArgumentNullException();

            var book = new Book {
                Title = bookData.Title,
                Author = bookData.Author,
                Year = year,
                Genre = bookData.Genre
            };

            _bookRepository.Create(book);
        }

        public List<Book> FindAllBooks()
        {
            return _bookRepository.FindAll();
        }

        public void UpdateBook(BookData bookData)
        {
            if (string.IsNullOrEmpty(bookData.Title))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookData.Author))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookData.Year))
                throw new ArgumentNullException();

            if (!int.TryParse(bookData.Year, out int year))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookData.Genre))
                throw new ArgumentNullException();

            if (_bookRepository.FindById(bookData.Id) == null)
                throw new BookNotFoundException();

            var book = new Book
            {
                Title = bookData.Title,
                Author = bookData.Author,
                Year = year,
                Genre = bookData.Genre
            };

            _bookRepository.UpdateById(bookData.Id, book);
        }

        public void DeleteBook(BookData bookData)
        {
            if (_bookRepository.FindById(bookData.Id) == null)
                throw new BookNotFoundException();

            _bookRepository.DeleteById(bookData.Id);
        }

        public void HandOverBook(BookData bookData, UserData userData)
        {
            if (_bookRepository.FindById(bookData.Id) == null)
                throw new BookNotFoundException();

            if (_userRepository.FindById(userData.Id) == null)
                throw new UserNotFoundException();

            if (_bookRepository.IsExist(bookData.Id))
                throw new BookExistException();

            _bookRepository.HandOverById(bookData.Id, userData.Id);
        }

        public void ReturnBook(BookData bookData)
        {
            if (_bookRepository.FindById(bookData.Id) == null)
                throw new BookNotFoundException();

            _bookRepository.ReturnById(bookData.Id);
        }

        public List<Book> FindBooksByGenreAndYear(BookData bookData)
        {
            if (string.IsNullOrEmpty(bookData.Genre))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookData.StartYear))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookData.EndYear))
                throw new ArgumentNullException();

            if (!int.TryParse(bookData.StartYear, out int year1))
                throw new ArgumentNullException();

            if (!int.TryParse(bookData.EndYear, out int year2))
                throw new ArgumentNullException();

            var books = _bookRepository.FindByGenreAndYear(bookData.Genre, year1, year2);

            if (books.Count == 0)
                throw new BookNotFoundException();

            return books;
        }

        public Book FindLastYearBook()
        {
            return _bookRepository.FindLastYear();
        }

        public int CountBooksByAuthor(BookData bookData)
        {
            if (string.IsNullOrEmpty(bookData.Author))
                throw new ArgumentNullException();

            var booksCount = _bookRepository.CountByAuthor(bookData.Author);

            if (booksCount == 0)
                throw new BookNotFoundException();

            return booksCount;
        }

        public int CountBooksByGenre(BookData bookData)
        {
            if (string.IsNullOrEmpty(bookData.Genre))
                throw new ArgumentNullException();

            var booksCount = _bookRepository.CountByGenre(bookData.Genre);

            if (booksCount == 0)
                throw new BookNotFoundException();

            return booksCount;
        }

        public Book ShowBookDescription(BookData bookData)
        {
            var book = _bookRepository.FindById(bookData.Id);

            if (book == null)
                throw new BookNotFoundException();

            return book;
        }
    }
}
