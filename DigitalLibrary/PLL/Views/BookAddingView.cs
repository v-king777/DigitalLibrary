using System;

namespace DigitalLibrary
{
    public class BookAddingView
    {
        private BookService _bookService;

        public BookAddingView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookAddingData = new BookAddingData();

            Console.WriteLine("Введите название книги:");
            bookAddingData.Title = Console.ReadLine();

            Console.WriteLine("Введите автора книги:");
            bookAddingData.Author = Console.ReadLine();

            Console.WriteLine("Введите год издания:");
            bookAddingData.Year = Console.ReadLine();

            Console.WriteLine("Введите жанр книги:");
            bookAddingData.Genre = Console.ReadLine();

            try
            {
                _bookService.AddBook(bookAddingData);

                SuccessMessage.Show("Книга успешно добавлена!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректные значения!");
            }

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка!\n" + ex.Message);
            }
        }
    }
}
