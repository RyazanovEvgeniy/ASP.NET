using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAspNet3.data.models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [DataType(DataType.Text)]
        public string name { get; set; }
        [DataType(DataType.Text)]
        public string surname { get; set; }
        [DataType(DataType.Text)]
        public string address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime dateTime { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public List<OrderDetail> orderDetails { get; set; }
    }
}
