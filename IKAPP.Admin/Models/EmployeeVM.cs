﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IKAPP.Admin.Models
{
    public class EmployeeVM
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
    }
}