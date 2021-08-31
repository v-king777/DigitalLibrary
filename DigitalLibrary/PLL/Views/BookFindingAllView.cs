using System;

namespace DigitalLibrary
{
    public class BookFindingAllView
    {
        private BookService _bookService;

        public BookFindingAllView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            try
            {
                var allBooks = _bookService.FindAllBooks();

                foreach (var book in allBooks)
                {
                    SuccessMessage.Show(
                        $"Id: {book.Id}, " +
                        $"Title: {book.Title}, " +
                        $"UserId (кому выдана): {book.UserId}");
                }
            }

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка!\n" + ex.Message);
            }
        }
    }
}
