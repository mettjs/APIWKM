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
    public class CafeteriaRepository : iCafeteriaRepository
    {
        private readonly MySqlConfiguration _connectionString;
        public CafeteriaRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<Cafeteria>> GetCafeterias()
        {
            var db = dbConnection();

            var sql = @"SELECT IDCombo, Nombre, Descripcion, Contenido, Precio, img FROM Cafeteria";

            return await db.QueryAsync<Cafeteria>(sql, new { });
        }

        public async Task<Cafeteria> GetCombo(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT IDCombo, Nombre, Descripcion, Contenido, Precio, img FROM Cafeteria WHERE IDCombo = @Id";

            return await db.QueryFirstOrDefaultAsync<Cafeteria>(sql, new { Id = id });
        }
    }
}
