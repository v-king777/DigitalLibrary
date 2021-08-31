using System;

namespace DigitalLibrary
{
    public class BookCountingByAuthorView
    {
        private BookService _bookService;

        public BookCountingByAuthorView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookFindingData = new BookData();

            Console.WriteLine("Введите автора книги:");
            bookFindingData.Author = Console.ReadLine();

            try
            {
                var count = _bookService.CountBooksByAuthor(bookFindingData.Author);

                SuccessMessage.Show($"Количество книг автора {bookFindingData.Author}: {count}");
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
