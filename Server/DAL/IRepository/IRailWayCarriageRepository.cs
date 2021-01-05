using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IRailWayCarriageRepository
    {
        Task<RailwayCarriage> Add(RailwayCarriage railWayCarriage);
        Task<int> GetNumberCarriage(int trainId);
        Task DeleteCarriage(int id);
        Task<RailwayCarriage> GetById(int id);
    }
}
