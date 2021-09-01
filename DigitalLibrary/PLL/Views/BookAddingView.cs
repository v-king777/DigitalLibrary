using System;

namespace DigitalLibrary
{
    public class BookAddingView
    {
        private readonly BookService _bookService;

        public BookAddingView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookData = new BookData();

            Console.WriteLine("Введите название книги:");
            bookData.Title = Console.ReadLine();

            Console.WriteLine("Введите автора книги:");
            bookData.Author = Console.ReadLine();

            Console.WriteLine("Введите год издания:");
            bookData.Year = Console.ReadLine();

            Console.WriteLine("Введите жанр книги:");
            bookData.Genre = Console.ReadLine();

            try
            {
                _bookService.AddBook(bookData);

                SuccessMessage.Show("Книга успешно добавлена!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка!\n" + ex.Message);
            }
        }
    }
}
