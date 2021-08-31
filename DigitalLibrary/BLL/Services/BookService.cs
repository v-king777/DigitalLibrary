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

        public void AddBook(BookAddingData bookAddingData)
        {
            if (string.IsNullOrEmpty(bookAddingData.Title))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookAddingData.Author))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookAddingData.Genre))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookAddingData.Year))
                throw new ArgumentNullException();

            var book = new Book {
                Title = bookAddingData.Title,
                Author = bookAddingData.Author,
                Genre = bookAddingData.Genre,
                Year = bookAddingData.Year
            };

            _bookRepository.Create(book);
        }

        public IEnumerable<Book> FindAllBooks()
        {
            return _bookRepository.FindAll();
        }
    }
}