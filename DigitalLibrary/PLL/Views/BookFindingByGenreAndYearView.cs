using System;

namespace DigitalLibrary
{
    class BookFindingByGenreAndYearView
    {
        private BookService _bookService;

        public BookFindingByGenreAndYearView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookFindingData = new BookData();

            Console.WriteLine("Введите жанр книги:");
            bookFindingData.Genre = Console.ReadLine();

            Console.WriteLine("Введите начальную дату:");
            bookFindingData.StartYear = Console.ReadLine();

            Console.WriteLine("Введите конечную дату:");
            bookFindingData.EndYear = Console.ReadLine();

            try
            {
                var books = _bookService.FindBooksByGenreAndYear(
                    bookFindingData.Genre, 
                    bookFindingData.StartYear, 
                    bookFindingData.EndYear);

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
