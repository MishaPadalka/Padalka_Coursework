using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Trains
{
    public class TrainDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string WhereGoes { set; get; }
        public string WhereFrom { set; get; }
        public DateTime Departure { set; get; }
        public DateTime Arrival { set; get; }
        public int FreePlaces { set; get; }
        public int OccupiedPlaces { set; get; }
        public Dictionary<string,int> TypesPlace { set; get; }
    }
}
