using System;

namespace DigitalLibrary
{
    public class UserBooksCountingView
    {
        private UserService _userService;

        public UserBooksCountingView(UserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            var findUserByIdData = new FindByIdData();

            Console.WriteLine("Введите Id пользователя:");
            int.TryParse(Console.ReadLine(), out int id);
            findUserByIdData.Id = id;

            try
            {
                var count = _userService.UserBooks(findUserByIdData);
                SuccessMessage.Show($"Количество выданных книг: {count}");
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
