using System;
using Analit.Common.Enums;

namespace Analit.Common.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public OrderStatus Status { get; set; }
    }
}