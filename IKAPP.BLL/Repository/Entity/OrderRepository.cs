using IKAPP.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.BLL.Repository.Entity
{
    public class OrderRepository : Base.BaseRepository<Order>
    {
        public void Update(Order gelen)
        {
            var bul = Find(gelen.ID);
            bul.OrderDate = gelen.OrderDate;
            bul.Piece = gelen.Piece;
            bul.Price = gelen.Price;
            bul.ProductID = gelen.ProductID;
            bul.CustomerID = gelen.CustomerID;
            bul.EmployeeID = gelen.EmployeeID;
            Save();
        }
    }
}
