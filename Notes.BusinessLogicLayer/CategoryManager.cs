using Notes.DataAccessLayer.Concrete;
using Notes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BusinessLogicLayer
{
    public class CategoryManager
    {
        private Repository<Category> repo_category = new Repository<Category>();
        public List<Category> GetListCategory()
        {
            List<Category> categoryList = repo_category.GetList();
            return categoryList;
        }

    }
}
