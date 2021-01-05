using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public int SeatId { set; get; }
        public Seat Seat { set; get; }
        public double Price { set; get; }
        public string BuyerFirstName { set; get; }
        public string BuyerLastName { set; get; }
    }
}
