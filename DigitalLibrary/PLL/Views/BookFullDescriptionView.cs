using System;

namespace DigitalLibrary
{
    class BookFullDescriptionView
    {
        private readonly BookService _bookService;

        public BookFullDescriptionView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookData = new BookData();

            Console.WriteLine("Введите Id книги:");
            int.TryParse(Console.ReadLine(), out int id);
            bookData.Id = id;

            try
            {
                var book = _bookService.ShowBookDescription(bookData);

                SuccessMessage.Show(
                    $"Id: {book.Id}\n" +
                    $"Title: {book.Title}\n" +
                    $"Author: {book.Author}\n" +
                    $"Year: {book.Year}\n" +
                    $"Genre: {book.Genre}\n" +
                    $"UserId (кому выдана): {book.UserId}");
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
