using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Seats
{
    public class OrderDTO
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public int NumberSeat { set; get; }
        public int NumberCarriage { set; get; }
        public string NameTrain { set; get; }
        public string WhereGoes { set; get; }
        public string WhereFrom { set; get; }
        public DateTime Departure { set; get; }
        public DateTime Arrival { set; get; }
        public double Price { set; get; }
        public string BuyerFirstName { set; get; }
        public string BuyerLastName { set; get; }
    }
}
