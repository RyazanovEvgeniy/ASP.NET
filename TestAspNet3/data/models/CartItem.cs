﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAspNet3.data.models
{
    public class CartItem
    {
        public int id { get; set; }
        public Product product { get; set; }
        public uint price { get; set; }
        public string itemCartId { get; set; }

    }
}
