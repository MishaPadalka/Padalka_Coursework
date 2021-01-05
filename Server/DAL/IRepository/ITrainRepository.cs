using Common.DTO.Trains;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface ITrainRepository
    {
        Task<Train> Add(Train train);
        Task<List<Train>> GetAll();
        Task<Train> GetById(int id);
        Task Delete(Train train);
        Task Update(Train train);
        Task<List<Train>> FindByKeyWord(string word);
    }
}
