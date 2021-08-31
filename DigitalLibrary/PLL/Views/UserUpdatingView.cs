using System;

namespace DigitalLibrary
{
    public class UserUpdatingView
    {
        private UserService _userService;

        public UserUpdatingView(UserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            var userUpdatingData = new UserUpdatingData();

            Console.WriteLine("Введите Id пользователя:");
            int.TryParse(Console.ReadLine(), out int id);
            userUpdatingData.Id = id; 

            Console.WriteLine("Введите новое имя пользователя:");
            userUpdatingData.Name = Console.ReadLine();

            Console.WriteLine("Введите новый адрес электронной почты:");
            userUpdatingData.Email = Console.ReadLine();

            try
            {
                _userService.UpdateUser(userUpdatingData);

                SuccessMessage.Show("Данные пользователя успешно обновлены!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректные данные!");
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
