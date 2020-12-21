using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IKAPP.Admin.Models
{
    public class OrderVM
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int ProductID { get; set; }
        public DateTime OrderDate { get; set; }
        public int Price { get; set; }
        public int Piece { get; set; }
    }
}