using IKAPP.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IKAPP.Admin.Models
{
    public class HomeVM
    {
        public List<Customer> musteriler { get; set; }
        public List<Order> siparisler { get; set; }
        public List<Product> urunler { get; set; }
    }
}