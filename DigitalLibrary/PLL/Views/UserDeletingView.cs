using System;

namespace DigitalLibrary
{
    public class UserDeletingView
    {
        private UserService _userService;

        public UserDeletingView(UserService userService)
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
                _userService.DeleteUser(findUserByIdData);

                SuccessMessage.Show("Пользователь успешно удалён!");
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
