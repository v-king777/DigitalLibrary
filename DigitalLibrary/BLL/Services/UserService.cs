using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public void AddUser(UserData userData)
        {
            if (string.IsNullOrEmpty(userData.Name))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userData.Email))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(userData.Email))
                throw new ArgumentNullException();

            if (_userRepository.FindByEmail(userData.Email) != null)
                throw new UserExistsException();

            var user = new User {
                Name = userData.Name,
                Email = userData.Email
            };

            _userRepository.Create(user);
        }

        public IEnumerable<User> FindAllUsers()
        {
            return _userRepository.FindAll();
        }

        public void UpdateUser(UserData userData)
        {
            if (string.IsNullOrEmpty(userData.Name))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userData.Email))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(userData.Email))
                throw new ArgumentNullException();

            if (_userRepository.FindByEmail(userData.Email) != null)
                throw new UserExistsException();

            if (_userRepository.FindById(userData.Id) == null)
                throw new UserNotFoundException();

            var user = new User
            {
                Name = userData.Name,
                Email = userData.Email
            };

            _userRepository.UpdateById(userData.Id, user);
        }

        public void DeleteUser(UserData userData)
        {
            if (_userRepository.FindById(userData.Id) == null)
                throw new UserNotFoundException();

            _userRepository.DeleteById(userData.Id);
        }

        public int CountUserBooks(UserData userData)
        {
            if (_userRepository.FindById(userData.Id) == null)
                throw new UserNotFoundException();

            return _userRepository.CountBooksById(userData.Id);
        }
    }
}
