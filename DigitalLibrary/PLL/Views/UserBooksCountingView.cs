using System;

namespace DigitalLibrary
{
    public class UserBooksCountingView
    {
        private readonly UserService _userService;

        public UserBooksCountingView(UserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            var userData = new UserData();

            Console.WriteLine("Введите Id пользователя:");
            int.TryParse(Console.ReadLine(), out int id);
            userData.Id = id;

            try
            {
                var count = _userService.UserBooks(userData);
                SuccessMessage.Show($"Количество выданных на руки книг: {count}");
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
