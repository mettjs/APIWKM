using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace API.Data.Repositories
{
    public class TicketRepository : iTicketRepository
    {
        private readonly MySqlConfiguration _connectionString;
        public TicketRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<Tickets> GetTicket(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT Pelicula, Fecha, ClienteID, Total FROM Tickets WHERE ClienteID = @Id";

            return await db.QueryFirstOrDefaultAsync<Tickets>(sql, new { Id = id });
        }
        public async Task<bool> CreateTicket(Tickets tickets)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO Tickets(Pelicula, Fecha, ClienteID, PeliculaID, SalaID, Total, ComboID) VALUES
                      (@Pelicula, @Fecha, @ClienteID, @PeliculaID, @SalaID, @Total, @ComboID)";

            var result = await db.ExecuteAsync(sql, new { tickets.Pelicula, tickets.Fecha, tickets.ClienteID, tickets.PeliculaID, tickets.SalaID, tickets.Total, tickets.ComboID });

            return result > 0;
        }
    }
}
