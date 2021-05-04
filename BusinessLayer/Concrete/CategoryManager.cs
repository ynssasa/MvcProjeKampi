using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repository = new GenericRepository<Category>();

        public List<Category> GetALL()
        {
            return repository.List();
        }

        public void Add(Category category)
        {
            if(category.CategoryName=="" || category.CategoryId <0)
            {
                //
            }
            else
            {
                repository.Insert(category);
            }
        }
    }
}
