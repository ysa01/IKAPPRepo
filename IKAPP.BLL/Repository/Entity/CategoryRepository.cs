using IKAPP.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.BLL.Repository.Entity
{
   public class CategoryRepository : Base.BaseRepository<Category>
    {
        public void Update(Category gelen)
        {
            var bul = Find(gelen.ID);
            bul.CategoryName = gelen.CategoryName;
            Save();
        }
    }
}
