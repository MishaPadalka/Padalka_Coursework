using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Carriages
{
    public class NewRailwayCarriage
    {
        public int TrainId { get; set; }
        public string Type { set; get; }
        public int CountSeats { set; get; }
        public double Price { set; get; }
    }
}
