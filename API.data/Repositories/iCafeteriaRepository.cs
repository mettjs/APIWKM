using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public interface iCafeteriaRepository
    {
        Task<IEnumerable<Cafeteria>> GetCafeterias();
        Task<Cafeteria> GetCombo(int id);
    }
}
