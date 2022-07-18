using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranferencia.MODEL;
using Transferencia.DATA.Repository;

namespace Transferencia.DATA
{
    public class EstadoDeCuentaRepository : IEstadodecuenta

    {
        private PostgreSQLConfiguration _connectionString;

        public EstadoDeCuentaRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public Task<bool> DeleteEstadoCuenta(EstadoDeCuenta cuenta)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EstadoDeCuenta>> GetAllEstadoCuenta()
        {
            var db = dbConnection();
            string sql = @"

           
            SELECT estado
         FROM transferencias;
            ";

           var result = await db.QueryAsync<EstadoDeCuenta>(sql);

            return result;
        }

        public Task<EstadoDeCuenta> GetEstadoCuentaDetails(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertEstadoCuenta(EstadoDeCuenta cuenta)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEstadoCuenta(EstadoDeCuenta cuenta)
        {
            throw new NotImplementedException();
        }
    }

}
