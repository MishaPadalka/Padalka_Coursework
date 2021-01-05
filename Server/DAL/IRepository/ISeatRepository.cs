using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface ISeatRepository
    {
        Task AddRange(IEnumerable<Seat> seats);
    }
}
