using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace PetFood.Data
{
    public class PetFoodFactoryData : IPetFoodFactoryData
    {
        static MappingSource _sharedMappingSource = new AttributeMappingSource();
        string _connectionString;
        public PetFoodDataContext PetFoodDataContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PetFoodDBConnectionString"].ConnectionString;
            return new PetFoodDataContext(_connectionString, _sharedMappingSource);
        }
    }
}