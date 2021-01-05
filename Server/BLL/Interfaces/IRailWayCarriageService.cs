using Common.DTO.Carriages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRailWayCarriageService
    {
        Task<RailwayCarriageDTO> Add(NewRailwayCarriage newRailway);
        Task DeleteCarriage(int id);
    }
}
