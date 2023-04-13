using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFood.Data
{
    public interface IPetFoodFactoryData
    {
        PetFoodDataContext PetFoodDataContext();
    }
}
