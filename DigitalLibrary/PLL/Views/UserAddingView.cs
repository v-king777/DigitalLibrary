using System;

namespace DigitalLibrary
{
    public class UserAddingView
    {
        private readonly UserService _userService;

        public UserAddingView(UserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            var userData = new UserData();

            Console.WriteLine("Введите имя пользователя:");
            userData.Name = Console.ReadLine();

            Console.WriteLine("Введите адрес электронной почты:");
            userData.Email = Console.ReadLine();

            try
            {
                _userService.AddUser(userData);

                SuccessMessage.Show("Пользователь успешно добавлен!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (UserExistsException)
            {
                AlertMessage.Show("Пользователь с таким email уже существует!");
            }

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка!\n" + ex.Message);
            }
        }
    }
}
