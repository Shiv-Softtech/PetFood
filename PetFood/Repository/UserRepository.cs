using PetFood.Data;
using PetFood.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetFood.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IPetFoodFactoryData _petFoodFactoryData;
        private PetFoodDataContext _petFoodDataContext;
        public UserRepository(IPetFoodFactoryData petFoodFactoryData)
        {
            _petFoodFactoryData = petFoodFactoryData;
            _petFoodDataContext = petFoodFactoryData.PetFoodDataContext();
        }
          /// <summary>
          /// insert user also check exist email
          /// </summary>
          /// <param name="userData"></param>
          /// <returns></returns>
        public bool InsertUser(User userData)
        {
            var isvalid = _petFoodDataContext.InsertUser_20221409(userData.Name,userData.Email,userData.Mobile,userData.Gender,userData.Hobbies,userData.Department,userData.Password).SingleOrDefault();
            bool valid = (bool)isvalid.Column1;
            return valid;
        }

        public User LoginAuth(User userData)
        {
            var loginDataRep = _petFoodDataContext.UserLogin_20220915(userData.Email, userData.Password);
            var loginData = (from o in loginDataRep
                             select new User
                             {
                                 Id = o.Id,
                                 Name = o.UserName,
                                Email = o.Email,    
                                Password = o.Password

                             }).FirstOrDefault();
            return loginData;
        }
    }
}