﻿using System;

namespace DigitalLibrary
{
    public class BookDeletingView
    {
        private BookService _bookService;

        public BookDeletingView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var findBookByIdData = new FindByIdData();

            Console.WriteLine("Введите Id книги:");
            int.TryParse(Console.ReadLine(), out int id);
            findBookByIdData.Id = id;

            try
            {
                _bookService.DeleteBook(findBookByIdData);

                SuccessMessage.Show("Книга успешно удалена!");
            }

            catch (BookNotFoundException)
            {
                AlertMessage.Show("Книга с таким Id не найдена!");
            }

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка!\n" + ex.Message);
            }
        }
    }
}
