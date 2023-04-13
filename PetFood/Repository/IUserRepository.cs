using PetFood.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFood.Repository
{
    public interface IUserRepository
    {
        bool InsertUser(User userData);
        User LoginAuth(User userData);
    }
}
