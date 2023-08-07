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
    public class ClientesRepository : iClientesRepository
    {
        private readonly MySqlConfiguration _connectionString;
        public ClientesRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> InsertClientes(Clientes clientes)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO Clientes(Nombre, Apellido, Correo) VALUES
                      (@Nombre, @Apellido, @Correo)";

            var result = await db.ExecuteAsync(sql, new { clientes.Nombre, clientes.Apellido, clientes.Correo });

            return result > 0;
        }

        public async Task<Clientes> GetClientes(string correo)
        {
            var db = dbConnection();

            var sql = @"SELECT ClienteID, Nombre, Apellido FROM Clientes WHERE correo = @Correo";

            return await db.QueryFirstOrDefaultAsync<Clientes>(sql, new { Correo = correo });
        }
    }
}
