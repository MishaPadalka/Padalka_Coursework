using BLL.Interfaces;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository seatRepository;
        public SeatService(ISeatRepository seatRepository)
        {
            this.seatRepository = seatRepository;
        }
    }
}
