using Common.DTO.Trains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITrainService
    {
        Task<TrainDTO> Add(NewTrain newTrain);
        Task<List<TrainDTO>> GetAll();
        Task<FullTrainDTO> GetTrainById(int id);
        Task DeleteTrain(int id);
        Task<List<TrainDTO>> FindByKeyWord(string word);
    }
}
