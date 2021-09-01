using System;

namespace DigitalLibrary
{
    public class BookCountingByAuthorView
    {
        private readonly BookService _bookService;

        public BookCountingByAuthorView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookData = new BookData();

            Console.WriteLine("Введите автора книги:");
            bookData.Author = Console.ReadLine();

            try
            {
                var booksCount = _bookService.CountBooksByAuthor(bookData);

                SuccessMessage.Show($"Количество книг автора {bookData.Author}: {booksCount}");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (BookNotFoundException)
            {
                AlertMessage.Show("Книги такого автора не найдены!");
            }

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка!\n" + ex.Message);
            }
        }
    }
}
