using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public interface iSalaRepository
    {
        Task<Sala> GetSala(int id);
        Task<bool> UpdateSala(Sala sala);
    }
}
