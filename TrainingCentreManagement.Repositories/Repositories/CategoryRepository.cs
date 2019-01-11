using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.Models.EntityModels;
using TrainingCentreManagement.Models.EntityModels.Categories;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.Repositories.Repositories
{
   public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
    }
}
