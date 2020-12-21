using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.BLL.DTO
{
    public class ProductCategoryDTO
    {
        public int ID { get; set; }
        public string Barcode { get; set; }
        public int CategoryID { get; set; }
        public bool CriticalStatus { get; set; }
        public int CriticalStock { get; set; }
        public double BuyPrice { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ProductName { get; set; }
        public double SellPrice { get; set; }
        public int Stock { get; set; }
        public int Tax { get; set; }
        public string CategoryName { get; set; }

    }
}
