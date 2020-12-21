using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IKAPP.Admin.Models
{
    public class ProductVM
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public float SellPrice { get; set; }
        public float BuyPrice { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public int Tax { get; set; }
        public int CriticalStock { get; set; }
        public bool CriticalStatus { get; set; }
        public bool IsActive { get; set; }
        public string Barcode { get; set; }

    }
}