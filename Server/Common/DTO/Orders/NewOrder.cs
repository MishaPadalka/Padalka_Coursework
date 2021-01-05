using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Seats
{
    public class NewOrder
    {
        public int SeatId { set; get; }
        public double Price { set; get; }
        public string BuyerFirstName { set; get; }
        public string BuyerLastName { set; get; }
    }
}
