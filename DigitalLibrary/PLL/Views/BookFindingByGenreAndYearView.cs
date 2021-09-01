using System;

namespace DigitalLibrary
{
    class BookFindingByGenreAndYearView
    {
        private readonly BookService _bookService;

        public BookFindingByGenreAndYearView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookData = new BookData();

            Console.WriteLine("Введите жанр книги:");
            bookData.Genre = Console.ReadLine();

            Console.WriteLine("Введите начальную дату:");
            bookData.StartYear = Console.ReadLine();

            Console.WriteLine("Введите конечную дату:");
            bookData.EndYear = Console.ReadLine();

            try
            {
                var books = _bookService.FindBooksByGenreAndYear(bookData);

                foreach (var book in books)
                {
                    SuccessMessage.Show(
                        $"Id: {book.Id}, " +
                        $"Title: {book.Title}, " +
                        $"UserId (кому выдана): {book.UserId}");
                }
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (BookNotFoundException)
            {
                AlertMessage.Show("По данному запросу ничего не найдено!");
            }

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка!\n" + ex.Message);
            }
        }
    }
}
