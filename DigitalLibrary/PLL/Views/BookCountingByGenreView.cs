using System;

namespace DigitalLibrary
{
    public class BookCountingByGenreView
    {
        private BookService _bookService;

        public BookCountingByGenreView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookFindingData = new BookData();

            Console.WriteLine("Введите жанр книги:");
            bookFindingData.Genre = Console.ReadLine();

            try
            {
                var count = _bookService.CountBooksByGenre(bookFindingData.Genre);

                SuccessMessage.Show($"Количество книг жанра {bookFindingData.Genre}: {count}");
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
