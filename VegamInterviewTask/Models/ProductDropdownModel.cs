using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VegamInterviewTask.Models
{
    public class ProductDropdownModel
    {
        public string OrderNum { get; set; }
        public string MaterialNo { get; set; }
        public string MaterialDesc { get; set; }
    }

    public class OrderDetails
    {
        public string MaterialNo { get; set; }
        public string MaterialDesc { get; set; }
        public string Batch { get; set; }
        public string Qty { get; set; }
        public string OrderDate { get; set; }
        public string ExpiryDate { get; set; }
        public int ShelfLife { get; set; }
    }
}