using System;

namespace DigitalLibrary
{
    public class BookHandOveringView
    {
        private readonly BookService _bookService;

        public BookHandOveringView(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Show()
        {
            var bookData = new BookData();
            var userData = new UserData();

            Console.WriteLine("Введите Id книги:");
            int.TryParse(Console.ReadLine(), out int bookId);
            bookData.Id = bookId;

            Console.WriteLine("Введите Id пользователя:");
            int.TryParse(Console.ReadLine(), out int userId);
            userData.Id = userId;

            try
            {
                _bookService.HandOverBook(bookData, userData);

                SuccessMessage.Show($"Книга успешно выдана пользователю!");
            }

            catch (BookNotFoundException)
            {
                AlertMessage.Show("Книга с таким Id не найдена!");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь с таким Id не найден!");
            }

            catch (BookExistException)
            {
                AlertMessage.Show("Книга с таким Id уже на руках!");
            }

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка!\n" + ex.Message);
            }
        }
    }
}
