using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Seat
    {
        public int Id { set; get; }
        public int NumberSeat { set; get; }
        public int RailwayCarriageId { get; set; }
        public double Price { set; get; }
        public RailwayCarriage RailwayCarriage { get; set; }
        public Order Order { set; get; }
    }
}
