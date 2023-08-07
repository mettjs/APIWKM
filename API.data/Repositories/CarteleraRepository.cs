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
    public class CarteleraRepository : iCarteleraRepository
    {
        private readonly MySqlConfiguration _connectionString;
        public CarteleraRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<Cartelera>> GetAllCarteleras()
        {
            var db = dbConnection();

            var sql = @"SELECT CarteleraID, Pelicula, sinopsis, Estreno, Genero, Duracion, IDPelicula, img FROM Cartelera";

            return await db.QueryAsync<Cartelera>(sql, new { });
        }
        public async Task<Cartelera> GetbyId(int Id)
        {
            var db = dbConnection();

            var sql = @"SELECT CarteleraID, Pelicula, sinopsis, Estreno, Genero, Duracion, IDPelicula, img FROM Cartelera WHERE IDPelicula = @Id";

            return await db.QueryFirstOrDefaultAsync<Cartelera>(sql, new { Id = Id });
        }
    }
}
