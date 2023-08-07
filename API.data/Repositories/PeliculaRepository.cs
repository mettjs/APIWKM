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
    public class PeliculaRepository : iPeliculasRepository
    {
        private readonly MySqlConfiguration _connectionString;
        public PeliculaRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<Peliculas> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id, Titulo, Director, Sinopsis, Reparto, Duracion, Genero, Estreno, Trailer, img FROM Peliculas WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Peliculas>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Peliculas>> GetPeliculas()
        {
            var db = dbConnection();

            var sql = @"SELECT ID, Titulo, Director, Sinopsis, Reparto, Duracion, Genero, Estreno, Trailer, img FROM Peliculas";

            return await db.QueryAsync<Peliculas>(sql, new { });
        }
        public async Task<bool> DeletePeliculas(Peliculas peliculas)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Peliculas WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new Peliculas { Id = peliculas.Id });

            return result > 0;
        }
        public async Task<bool> InsertPeliculas(Peliculas peliculas)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO Peliculas(Titulo, Director, Sinopsis, Reparto, Duracion, Genero, Estreno, Trailer, img) VALUES
                      (@Titulo, @Director, @Sinopsis, @Reparto, @Duracion, @Genero, @Estreno, @Trailer, @img)";

            var result = await db.ExecuteAsync(sql, new { peliculas.Titulo, peliculas.Director, peliculas.Sinopsis, peliculas.Reparto, peliculas.Duracion, peliculas.Genero, peliculas.Estreno, peliculas.Trailer, peliculas.img });

            return result > 0;
        }

        public async Task<bool> UpdatePeliculas(Peliculas peliculas)
        {
            var db = dbConnection();

            var sql = @"UPDATE Peliculas
                        SET titulo = @Titulo,
                        director = @Director,
                        sinopsis = @Sinopsis,
                        reparto = @Reparto,
                        duracion = @Duracion,
                        genero = @Genero,
                        estreno = @Estreno,
                        trailer = @Trailer
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { peliculas.Titulo, peliculas.Director, peliculas.Sinopsis, peliculas.Reparto, peliculas.Duracion, peliculas.Genero, peliculas.Estreno, peliculas.Trailer, peliculas.Id});

            return result > 0;
        }
    }
}
