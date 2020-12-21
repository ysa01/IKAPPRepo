using IKAPP.BLL.DTO;
using IKAPP.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.BLL.Repository.Entity
{
    public class ProductRepository : Base.BaseRepository<Product>
    {
        public ProductCategoryDTO BarSearch(string brc)
        {
            CategoryRepository cat = new CategoryRepository();
            List<Category> li = cat.GetAll();

            var bul = (from p in this.GetAll()
                       where p.Barcode == brc
                       join c in li on p.CategoryID equals c.ID
                       select new ProductCategoryDTO
                       {
                           ID=p.ID,
                           Barcode =p.Barcode,
                           BuyPrice = (double)p.BuyPrice,
                           CategoryID =c.ID,
                           CategoryName=c.CategoryName,
                           CriticalStatus =(bool)p.CriticalStatus,
                           CriticalStock= (int)p.CriticalStock,
                           Description = p.Description,
                           IsActive= (bool)p.IsActive,
                           ProductName = p.ProductName,
                           SellPrice=(double)p.SellPrice,
                           Stock= (int)p.Stock,
                           Tax = (int)p.Tax
                       }).SingleOrDefault();
            return bul;
        }
      

        public void StockStatus(int adet, int ID)
        {
            var bul = this.GetAll().Where(x => x.ID == ID).SingleOrDefault();
            if (bul != null)
            {
                if (bul.Stock > 0)
                {
                    bul.Stock -= adet;
                    if (bul.Stock <= bul.CriticalStock)
                    {
                        bul.CriticalStatus = true;
                        Save();
                    }
                }
            }
        }
    }
}
