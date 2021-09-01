using System;

namespace DigitalLibrary
{
    public class BookCountingByGenreView
    {
        private readonly BookService _bookService;

        public BookCountingByGenreView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookData = new BookData();

            Console.WriteLine("Введите жанр книги:");
            bookData.Genre = Console.ReadLine();

            try
            {
                var bookCount = _bookService.CountBooksByGenre(bookData);

                SuccessMessage.Show($"Количество книг жанра {bookData.Genre}: {bookCount}");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (BookNotFoundException)
            {
                AlertMessage.Show("Книги такого жанра не найдены!");
            }

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка!\n" + ex.Message);
            }
        }
    }
}
