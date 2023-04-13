using PetFood.Entity;
using PetFood.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetFood.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool InsertUser(User userdata)
        {
           return _userRepository.InsertUser(userdata);
        }

        public User LoginAuth(User userData)
        {
            return _userRepository.LoginAuth(userData);
        }
    }
}