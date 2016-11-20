using System;
using System.Collections.Generic;
using Analit.Common.Enums;

namespace Analit.Common.Models
{
    public class Order
    {
        public Order()
        {
            Created = DateTime.Now;
            OrderProducts = new List<OrderProduct>();
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public OrderStatus Status { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}