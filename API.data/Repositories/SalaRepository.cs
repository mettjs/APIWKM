using API.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public class SalaRepository : iSalaRepository
    {
        private readonly MySqlConfiguration _connectionString;
        public SalaRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<Sala> GetSala(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT IDSala, Asientos FROM Sala WHERE PeliculaID = @Id";

            return await db.QueryFirstOrDefaultAsync<Sala>(sql, new { Id = id });
        }

        public async Task<bool> UpdateSala(Sala sala)
        {
            var db = dbConnection();

            var sql = @"UPDATE Sala
                        SET asientos = @Asientos
                        WHERE IDSala = @IDSala";

            var result = await db.ExecuteAsync(sql, new { sala.Asientos, sala.IDSala, sala.PeliculaID });

            return result > 0;
        }
    }
}
