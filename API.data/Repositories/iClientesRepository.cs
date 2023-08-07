using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public interface iClientesRepository
    {
        Task<Clientes> GetClientes(string correo);
        Task<bool> InsertClientes(Clientes clientes);
    }
}
