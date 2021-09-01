using System;

namespace DigitalLibrary
{
    public class BookUpdatingView
    {
        private readonly BookService _bookService;

        public BookUpdatingView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookData = new BookData();

            Console.WriteLine("Введите Id книги:");
            int.TryParse(Console.ReadLine(), out int id);
            bookData.Id = id;

            Console.WriteLine("Введите новое название книги:");
            bookData.Title = Console.ReadLine();

            Console.WriteLine("Введите нового автора книги:");
            bookData.Author = Console.ReadLine();

            Console.WriteLine("Введите новый год издания книги:");
            bookData.Year = Console.ReadLine();

            Console.WriteLine("Введите новый жанр книги:");
            bookData.Genre = Console.ReadLine();

            try
            {
                _bookService.UpdateBook(bookData);

                SuccessMessage.Show("Данные книги успешно обновлены!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
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
