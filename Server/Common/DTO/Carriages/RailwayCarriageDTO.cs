using Common.DTO.Seats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Carriages
{
    public class RailwayCarriageDTO
    {
        public int Id { set; get; }
        public int Number { set; get; }
        public string Type { set; get; }
        public ICollection<SeatDTO> Seats { set; get; }
    }
}
