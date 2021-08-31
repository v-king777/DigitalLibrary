using System;

namespace DigitalLibrary
{
    public class BookUpdatingView
    {
        private BookService _bookService;

        public BookUpdatingView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookUpdatingData = new BookData();

            Console.WriteLine("Введите Id книги:");
            int.TryParse(Console.ReadLine(), out int id);
            bookUpdatingData.Id = id;

            Console.WriteLine("Введите новое название книги:");
            bookUpdatingData.Title = Console.ReadLine();

            Console.WriteLine("Введите нового автора книги:");
            bookUpdatingData.Author = Console.ReadLine();

            Console.WriteLine("Введите новый год издания книги:");
            bookUpdatingData.Year = Console.ReadLine();

            Console.WriteLine("Введите новый жанр книги:");
            bookUpdatingData.Genre = Console.ReadLine();

            try
            {
                _bookService.UpdateBook(bookUpdatingData);

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
