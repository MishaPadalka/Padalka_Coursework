using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Trains
{
    public class NewTrain
    {
        public string Name { set; get; }
        public string WhereGoes { set; get; }
        public string WhereFrom { set; get; }
        public DateTime Departure { set; get; }
        public DateTime Arrival { set; get; }
    }
}
