using System;
using System.Collections.Generic;

namespace DigitalLibrary
{
    public class BookService
    {
        private IBookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public void AddBook(BookData bookAddingData)
        {
            if (string.IsNullOrEmpty(bookAddingData.Title))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookAddingData.Author))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookAddingData.Year))
                throw new ArgumentNullException();

            if (!int.TryParse(bookAddingData.Year, out int year))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookAddingData.Genre))
                throw new ArgumentNullException();

            var book = new Book {
                Title = bookAddingData.Title,
                Author = bookAddingData.Author,
                Year = year,
                Genre = bookAddingData.Genre
            };

            _bookRepository.Create(book);
        }

        public IEnumerable<Book> FindAllBooks()
        {
            return _bookRepository.FindAll();
        }

        public void UpdateBook(BookData bookUpdatingData)
        {
            if (string.IsNullOrEmpty(bookUpdatingData.Title))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookUpdatingData.Author))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookUpdatingData.Year))
                throw new ArgumentNullException();

            if (!int.TryParse(bookUpdatingData.Year, out int year))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookUpdatingData.Genre))
                throw new ArgumentNullException();

            if (_bookRepository.FindById(bookUpdatingData.Id) == null)
                throw new BookNotFoundException();

            var book = new Book
            {
                Title = bookUpdatingData.Title,
                Author = bookUpdatingData.Author,
                Year = year,
                Genre = bookUpdatingData.Genre
            };

            _bookRepository.UpdateById(bookUpdatingData.Id, book);
        }

        public void DeleteBook(BookData findBookByIdData)
        {
            if (_bookRepository.FindById(findBookByIdData.Id) == null)
                throw new BookNotFoundException();

            _bookRepository.DeleteById(findBookByIdData.Id);
        }

        public void HandOverBook(BookData findBookByIdData, BookData findUserByIdData)
        {
            if (_bookRepository.FindById(findBookByIdData.Id) == null)
                throw new BookNotFoundException();

            if (_bookRepository.FindById(findUserByIdData.Id) == null)
                throw new UserNotFoundException();

            if (_bookRepository.IsExist(findBookByIdData.Id))
                throw new BookExistException();

            _bookRepository.HandOverById(findBookByIdData.Id, findUserByIdData.Id);
        }

        public void ReturnBook(BookData findBookByIdData)
        {
            if (_bookRepository.FindById(findBookByIdData.Id) == null)
                throw new BookNotFoundException();

            _bookRepository.ReturnById(findBookByIdData.Id);
        }

        public IEnumerable<Book> FindBooksByGenreAndYear(string genre, string startYear, string endYear)
        {
            if (string.IsNullOrEmpty(genre))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(startYear))
                throw new ArgumentNullException();

            if (!int.TryParse(startYear, out int year1))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(endYear))
                throw new ArgumentNullException();

            if (!int.TryParse(endYear, out int year2))
                throw new ArgumentNullException();

            return _bookRepository.FindByGenreAndYear(genre, year1, year2);
        }
    }
}
