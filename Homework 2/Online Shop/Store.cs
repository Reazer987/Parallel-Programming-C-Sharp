using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop
{
   public class Store
    {
        public Store(List<int> customers, List<int> suplyers, List<int> orders)
        {
            Customers = customers;
            Suplyers = suplyers;
            Orders = orders;
        }

        public List<int>  Customers { get; set; }
        public List<int> Suplyers { get; set; }
        public List<int> Orders { get; set; }

       
    }
}
