using System;

namespace DigitalLibrary
{
    public class BookReturningView
    {
        private BookService _bookService;

        public BookReturningView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var findBookByIdData = new FindByIdData();

            Console.WriteLine("Введите Id книги:");
            int.TryParse(Console.ReadLine(), out int bookId);
            findBookByIdData.Id = bookId;

            try
            {
                _bookService.ReturnBook(findBookByIdData);

                SuccessMessage.Show($"Книга успешно возвращена в библиотеку");
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
