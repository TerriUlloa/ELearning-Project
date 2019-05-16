using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.DAL
{
    public interface ICategoryDAL
    {
        IList<Category> GetCategories();
        Category GetCategory(int id);
        void SaveCategory(Category cat);
    }
}
