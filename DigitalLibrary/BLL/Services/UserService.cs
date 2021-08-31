using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public void AddUser(UserData userAddingData)
        {
            if (string.IsNullOrEmpty(userAddingData.Name))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userAddingData.Email))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(userAddingData.Email))
                throw new ArgumentNullException();

            if (_userRepository.FindByEmail(userAddingData.Email) != null)
                throw new UserExistsException();

            var user = new User {
                Name = userAddingData.Name,
                Email = userAddingData.Email
            };

            _userRepository.Create(user);
        }

        public List<User> FindAllUsers()
        {
            return _userRepository.FindAll();
        }

        public void UpdateUser(UserData userUpdatingData)
        {
            if (string.IsNullOrEmpty(userUpdatingData.Name))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userUpdatingData.Email))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(userUpdatingData.Email))
                throw new ArgumentNullException();

            if (_userRepository.FindByEmail(userUpdatingData.Email) != null)
                throw new UserExistsException();

            if (_userRepository.FindById(userUpdatingData.Id) == null)
                throw new UserNotFoundException();

            var user = new User
            {
                Name = userUpdatingData.Name,
                Email = userUpdatingData.Email
            };

            _userRepository.UpdateById(userUpdatingData.Id, user);
        }

        public void DeleteUser(UserData findUserByIdData)
        {
            if (_userRepository.FindById(findUserByIdData.Id) == null)
                throw new UserNotFoundException();

            _userRepository.DeleteById(findUserByIdData.Id);
        }

        public int UserBooks(UserData findUserByIdData)
        {
            if (_userRepository.FindById(findUserByIdData.Id) == null)
                throw new UserNotFoundException();

            return _userRepository.CountBooksById(findUserByIdData.Id);
        }
    }
}
