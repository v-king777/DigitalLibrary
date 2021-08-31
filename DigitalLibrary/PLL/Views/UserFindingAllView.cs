using System;

namespace DigitalLibrary
{
    public class UserFindingAllView
    {
        private UserService _userService;

        public UserFindingAllView(UserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            try
            {
                var allUsers = _userService.FindAllUsers();

                foreach (var user in allUsers)
                {
                    SuccessMessage.Show(
                        $"Id: {user.Id}, " +
                        $"Name: {user.Name}, " +
                        $"Email: {user.Email}");
                }
            }

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка!\n" + ex.Message);
            }
        }
    }
}
