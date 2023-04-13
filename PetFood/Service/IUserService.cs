using PetFood.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFood.Service
{
    public interface IUserService
    {
        bool InsertUser(User userdata);
        User LoginAuth(User userData);

    }
}
