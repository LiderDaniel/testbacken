using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranferencia.MODEL;

namespace Transferencia.DATA.Repository
{
    public class BancoRepository : IBanco
    {
        private PostgreSQLConfiguration _connectionString;

        public BancoRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeleteBanco(BANCO banco)
        {
            var db = dbConnection();

            var sql = @"
                    DELETE  
                    FROM public.""banco""
                    WHERE codigo_banco =@codigo_banco
                   
                    ";

            var result = await db.ExecuteAsync(sql, new { codigo_banco = banco.codigo_banco });
            return result > 0;
        }

        public async Task<IEnumerable<BANCO>> GetAllBanco()
        {
            var db = dbConnection();
            string sql = @"
            
             SELECT * FROM banco
            ";

            var response = await db.QueryAsync<BANCO>(sql);

            return response;
        }

        public async Task<BANCO> GetBancoDetails(string COD)
        {
            var db = dbConnection();

            var sql = @"
                    SELECT *FROM public.banco
                    WHERE codigo_banco = @codigo_banco
                    ";

            return await db.QueryFirstOrDefaultAsync<BANCO>(sql, new { codigo_banco = COD  });


           
        }

        public async Task<bool> InsertBanco(BANCO banco)
        {
            var db = dbConnection();

            var sql = @"
                    INSERT INTO public.""banco""(codigo_banco, direccion, nombre_banco)
                    VALUES(@codigo_banco,@DIRECCION,@NOMBRE_BANCO)
                   
                   
                  
                    ";

            var result = await db.ExecuteAsync(sql, new { banco.codigo_banco, banco.DIRECCION, banco.NOMBRE_BANCO });
            return result > 0;
        }

        public async Task<bool> UpdateBanco(BANCO banco)
        {
            var db = dbConnection();

            string sql = @"
                    UPDATE banco
                    SET  direccion = @DIRECCION ,
                        nombre_banco = @NOMBRE_BANCO 
                    WHERE codigo_banco= @codigo_banco";

            var result = await db.ExecuteAsync(sql, new { banco.DIRECCION, banco.NOMBRE_BANCO, banco.codigo_banco });
            return result > 0;
        }
    }
}