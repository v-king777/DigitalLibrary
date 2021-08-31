using System;

namespace DigitalLibrary
{
    public class BookDeletingView
    {
        private BookService _bookService;

        public BookDeletingView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var findByIdData = new FindByIdData();

            Console.WriteLine("Введите Id книги:");
            int.TryParse(Console.ReadLine(), out int id);
            findByIdData.Id = id;

            try
            {
                _bookService.DeleteBook(findByIdData);

                SuccessMessage.Show("Книга успешно удалена!");
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
