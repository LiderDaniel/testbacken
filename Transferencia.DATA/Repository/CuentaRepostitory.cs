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
    public class CuentaRepostitory : ICuenta
    {
        private PostgreSQLConfiguration _connectionString;

        public CuentaRepostitory(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
         protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteCuenta(CUENTA cuenta)
        {
           var db = dbConnection();

            var sql = @"
                    DELETE  
                    FROM public.""cuenta""
                    WHERE id_cta =@ID_CTA
                   

                    ";

            var result= await db.ExecuteAsync(sql, new { ID_CTA = cuenta.ID_CTA });
            return result > 0;
        }

        public  async Task<IEnumerable<CUENTA>> GetAllCuenta()
        {
            var db = dbConnection();

            string sql = @"
                      SELECT * FROM cuenta
                    ";

           var result = await db.QueryAsync<CUENTA>(sql);
            return result;
        }

        public async Task<CUENTA> GetCuentaDetails(string IDCUEN)
        {
            var db = dbConnection();

            var sql = @"
                    SELECT * FROM public.cuenta
                    WHERE id_cta =@ID_CTA";

            return await db.QueryFirstOrDefaultAsync<CUENTA>(sql, new { ID_CTA = IDCUEN});

        }

        public  async Task<bool> InsertCuenta(CUENTA cuenta)
        {
            var db = dbConnection();

            var sql = @"
              INSERT INTO public.""cuenta""(id_cta,num_cta, moneda, cedula_cliente, saldo,cod_banco)
            VALUES(@ID_CTA, @NUM_CTA, @MONEDA, @CEDULA_CLIENTE, @SALDO , @COD_BANCO)
        ";

            var result = await db.ExecuteAsync(sql, new { cuenta.ID_CTA, cuenta.NUM_CTA, cuenta.MONEDA, cuenta.CEDULA_CLIENTE, cuenta.SALDO, cuenta.COD_BANCO });
            return result > 0;  
        }

        public async Task<bool> UpdateCuenta(CUENTA cuenta)
        {
            var db = dbConnection();

            string sql = @"
 
                 UPDATE cuenta
                 SET  num_cta =  @NUM_CTA,
                     moneda =  @MONEDA,
                     saldo = @SALDO,
                    cod_banco = @COD_BANCO
                    
                WHERE id_cta = @id_cta

                    
";
            var result = await db.ExecuteAsync(sql, new { cuenta.ID_CTA, cuenta.NUM_CTA, cuenta.MONEDA, cuenta.CEDULA_CLIENTE, cuenta.SALDO, cuenta.COD_BANCO });
            return result > 0;
        }
    }
    }

