using Data.API.Context;
using Data.API.Dal.CategoryDal.Abstract;
using Data.API.Repositories.Cocrate;
using Entity.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.Dal.CategoryDal.Cocrate
{
    public class CategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public CategoryDal(AppDbContext context) : base(context)
        {
        }
    }
}
