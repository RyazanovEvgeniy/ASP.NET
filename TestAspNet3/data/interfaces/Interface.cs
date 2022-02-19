using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.models;

namespace TestAspNet3.data.interfaces
{
    public interface IOrders
    {
        void CreateOrder(Order order);
    }
}
