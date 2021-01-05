using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Seats
{
    public class SeatDTO
    {
        public int Id { set; get; }
        public int NumberSeat { set; get; }
        public bool Free { set; get; }
        public double Price { set; get; }
    }
}
