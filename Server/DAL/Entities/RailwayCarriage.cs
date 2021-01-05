using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class RailwayCarriage
    {
        public int Id { set; get; }
        public int Number { set; get; }
        public int TrainId { get; set; }
        public Train Train { get; set; }
        public string Type { set; get; }
        public ICollection<Seat> Seats { set; get; }
    }
}
