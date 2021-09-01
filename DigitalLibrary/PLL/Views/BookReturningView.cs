using System;

namespace DigitalLibrary
{
    public class BookReturningView
    {
        private readonly BookService _bookService;

        public BookReturningView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookData = new BookData();

            Console.WriteLine("Введите Id книги:");
            int.TryParse(Console.ReadLine(), out int bookId);
            bookData.Id = bookId;

            try
            {
                _bookService.ReturnBook(bookData);

                SuccessMessage.Show($"Книга успешно возвращена в библиотеку");
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
