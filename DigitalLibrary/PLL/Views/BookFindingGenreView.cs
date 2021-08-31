using System;

namespace DigitalLibrary
{
    class BookFindingGenreView
    {
        private BookService _bookService;

        public BookFindingGenreView(BookService bookService)
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
                var books = _bookService.FindBooksByGenre(bookFindingData.Genre);

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

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка!\n" + ex.Message);
            }
        }
    }
}
