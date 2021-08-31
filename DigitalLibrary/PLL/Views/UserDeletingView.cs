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
            var deletingByIdData = new DeletingByIdData();

            Console.WriteLine("Введите Id пользователя:");
            int.TryParse(Console.ReadLine(), out int id);
            deletingByIdData.Id = id;

            try
            {
                _userService.DeleteUser(deletingByIdData);

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
