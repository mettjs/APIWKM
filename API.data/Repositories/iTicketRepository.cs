using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public interface iTicketRepository
    {
        Task<Tickets> GetTicket(int id);
        Task<bool> CreateTicket(Tickets tickets);
    }
}
