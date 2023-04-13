using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetFood.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Hobbies { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

    }
}