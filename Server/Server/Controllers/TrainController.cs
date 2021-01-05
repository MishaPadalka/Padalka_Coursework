using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Common.DTO.Trains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService trainService;
        public TrainController(ITrainService trainService)
        {
            this.trainService = trainService;
        }

        [HttpGet]
        public async Task<List<TrainDTO>> GetAll()
        {
            return await trainService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<FullTrainDTO> GetTrain(int id)
        {
            return await trainService.GetTrainById(id);
        }

        [HttpPost]
        public async Task<TrainDTO> Add(NewTrain newTrain)
        {
           return await trainService.Add(newTrain);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await trainService.DeleteTrain(id);
        }
        [HttpGet("search/{word}")]
        public async Task<List<TrainDTO>> FindByWord(string word)
        {
            return await trainService.FindByKeyWord(word);
        }
    }
}