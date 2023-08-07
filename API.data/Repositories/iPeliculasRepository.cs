using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public interface iPeliculasRepository
    {
        Task<IEnumerable<Peliculas>> GetPeliculas();
        Task<Peliculas> GetDetails(int id);
        Task<bool> UpdatePeliculas(Peliculas peliculas);
        Task<bool> DeletePeliculas(Peliculas peliculas);
        Task<bool> InsertPeliculas(Peliculas peliculas);
    }
}
