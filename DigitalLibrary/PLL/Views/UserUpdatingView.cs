using System;

namespace DigitalLibrary
{
    public class UserUpdatingView
    {
        private readonly UserService _userService;

        public UserUpdatingView(UserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            var userData = new UserData();

            Console.WriteLine("Введите Id пользователя:");
            int.TryParse(Console.ReadLine(), out int id);
            userData.Id = id; 

            Console.WriteLine("Введите новое имя пользователя:");
            userData.Name = Console.ReadLine();

            Console.WriteLine("Введите новый адрес электронной почты:");
            userData.Email = Console.ReadLine();

            try
            {
                _userService.UpdateUser(userData);

                SuccessMessage.Show("Данные пользователя успешно обновлены!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (UserExistsException)
            {
                AlertMessage.Show("Пользователь с таким email уже существует!");
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
