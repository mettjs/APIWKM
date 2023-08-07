using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Model;

namespace API.Data.Repositories
{
    public interface iCarteleraRepository
    {
        Task<IEnumerable<Cartelera>> GetAllCarteleras();
        Task<Cartelera> GetbyId(int Id);
    }
}
