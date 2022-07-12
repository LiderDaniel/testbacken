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


        public  async Task<bool> DeleteBanco(BANCO banco)
        {
            var db = dbConnection();

            var sql = @"
                    DELETE  
                    FROM public.""banco""
                    WHERE codigo_banco =@COD_BANCO
                   

                    ";

            var result = await db.ExecuteAsync(sql, new { COD_BANCO = banco.COD_BANCO });
            return result > 0;
        }

        public  async Task<IEnumerable<BANCO>> GetAllBanco()
        {
            var db = dbConnection();

            var sql = @"
                    SELECT codigo_banco, direccion, nombre_banco
                    FROM public.""banco""

                    ";

            return await db.QueryAsync<BANCO>(sql, new { });
        }

        public async Task<BANCO> GetBancoDetails(string id)
        {
            var db = dbConnection();

            var sql = @"
                    SELECT codigo_banco, direccion, nombre_banco
                    FROM public.""banco""
                    WHERE codigo_banco =@COD_BANCO
                    ";

            return await db.QueryFirstOrDefaultAsync<BANCO>(sql, new { });
        }

        public async Task<bool> InsertBanco(BANCO banco)
        {
            var db = dbConnection();

            var sql = @"

                    INSERT INTO public.""banco""(codigo_banco, direccion, nombre_banco)
                    VALUES(@COD_BANCO,@DIRECCION,@NOMBRE_BANCO)
                   
                   
                  
                    ";

            var result = await db.ExecuteAsync(sql, new { banco.COD_BANCO, banco.DIRECCION, banco.NOMBRE_BANCO });
            return result > 0;
        }

        public  async   Task<bool> UpdateBanco(BANCO banco)
        {
            var db = dbConnection();

            var sql = @"

                    UDPATE INTO public.""banco""
                    SET codigo_banco= @COD_BANCO ,
                        direccion= @DIRECCION ,
                        nombre_banco= @NOMBRE_BANCO ,
                    WHERE codigo_banco= @COD_BANCO

                    ";

            var result = await db.ExecuteAsync(sql, new { banco.COD_BANCO, banco.DIRECCION, banco.NOMBRE_BANCO });
            return result > 0;
        }
    }
}
