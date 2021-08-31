using System;

namespace DigitalLibrary
{
    public class BookHandOveringView
    {
        private BookService _bookService;

        public BookHandOveringView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var findBookByIdData = new FindByIdData();
            var findUserByIdData = new FindByIdData();

            Console.WriteLine("Введите Id книги:");
            int.TryParse(Console.ReadLine(), out int bookId);
            findBookByIdData.Id = bookId;

            Console.WriteLine("Введите Id пользователя:");
            int.TryParse(Console.ReadLine(), out int userId);
            findUserByIdData.Id = userId;

            try
            {
                _bookService.HandOverBook(findBookByIdData, findUserByIdData);

                SuccessMessage.Show($"Книга успешно выдана пользователю с Id: {findUserByIdData.Id}");
            }

            catch (BookNotFoundException)
            {
                AlertMessage.Show("Книга с таким Id не найдена!");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь с таким Id не найден!");
            }

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка!\n" + ex.Message);
            }
        }
    }
}
