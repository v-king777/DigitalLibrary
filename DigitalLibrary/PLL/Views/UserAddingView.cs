using System;

namespace DigitalLibrary
{
    public class UserAddingView
    {
        private UserService _userService;

        public UserAddingView(UserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            var userAddingData = new UserData();

            Console.WriteLine("Введите имя пользователя:");
            userAddingData.Name = Console.ReadLine();

            Console.WriteLine("Введите адрес электронной почты:");
            userAddingData.Email = Console.ReadLine();

            try
            {
                _userService.AddUser(userAddingData);

                SuccessMessage.Show("Пользователь успешно добавлен!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректные значения!");
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
