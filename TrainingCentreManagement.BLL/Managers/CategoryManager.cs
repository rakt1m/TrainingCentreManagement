using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels;
using TrainingCentreManagement.Models.EntityModels.Categories;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
   public class CategoryManager:Manager<Category>,ICategoryManager
    {
        public CategoryManager(ICategoryRepository repository) : base(repository)
        {
        }
    }
}
