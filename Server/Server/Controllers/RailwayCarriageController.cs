using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Common.DTO.Carriages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RailwayCarriageController : ControllerBase
    {
        private readonly IRailWayCarriageService railWayCarriageService;
        public RailwayCarriageController(IRailWayCarriageService railWayCarriageService)
        {
            this.railWayCarriageService = railWayCarriageService;
        }

        [HttpPost]
        public async Task<RailwayCarriageDTO> Add(NewRailwayCarriage newRailWay)
        {
            return await railWayCarriageService.Add(newRailWay);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await railWayCarriageService.DeleteCarriage(id);
        }
    }
}