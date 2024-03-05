using Carshop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Infrastructure.Repositories
{
    public interface ICarRepository
    {
        Task<Client> GetCarAsync(int id);
        Task<Client> UpdateCarAsync(Client client);
        Task<bool> DeleteCarAsync(int id);
    }
}
