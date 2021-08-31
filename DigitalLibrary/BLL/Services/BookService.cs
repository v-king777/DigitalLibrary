﻿using System;
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

        public void UpdateBook(BookUpdatingData bookUpdatingData)
        {
            if (string.IsNullOrEmpty(bookUpdatingData.Title))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookUpdatingData.Author))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookUpdatingData.Year))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(bookUpdatingData.Genre))
                throw new ArgumentNullException();

            if (_bookRepository.FindById(bookUpdatingData.Id) == null)
                throw new BookNotFoundException();

            var book = new Book
            {
                Title = bookUpdatingData.Title,
                Author = bookUpdatingData.Author,
                Year = bookUpdatingData.Year,
                Genre = bookUpdatingData.Genre
            };

            _bookRepository.UpdateById(bookUpdatingData.Id, book);
        }

        public void DeleteBook(FindByIdData findByIdData)
        {
            if (_bookRepository.FindById(findByIdData.Id) == null)
                throw new BookNotFoundException();

            _bookRepository.DeleteById(findByIdData.Id);
        }

        public void HandOverBook(FindByIdData findBookByIdData, FindByIdData findUserByIdData)
        {
            if (_bookRepository.FindById(findBookByIdData.Id) == null)
                throw new BookNotFoundException();

            if (_bookRepository.FindById(findUserByIdData.Id) == null)
                throw new UserNotFoundException();

            _bookRepository.HandOverById(findBookByIdData.Id, findUserByIdData.Id);
        }

        public void ReturnBook(FindByIdData findBookByIdData)
        {
            if (_bookRepository.FindById(findBookByIdData.Id) == null)
                throw new BookNotFoundException();

            _bookRepository.ReturnById(findBookByIdData.Id);
        }
    }
}
