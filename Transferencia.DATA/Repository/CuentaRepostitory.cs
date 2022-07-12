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

            var sql = @"
                    SELECT id_cta, num_cta, moneda, cedula_cliente , saldo, cod_banco
                    FROM public.""cuenta""

                    ";

            return await db.QueryAsync<CUENTA>(sql, new { });
        }

        public async Task<CUENTA> GetCuentaDetails(string id)
        {
            var db = dbConnection();

            var sql = @"
                    SELECT id_cta, num_cta, moneda, cedula_cliente , saldo, cod_banco
                    FROM public.""cuenta""
                    WHERE id_cta =@ID_CTA
                    ";

            return await db.QueryFirstOrDefaultAsync<CUENTA>(sql, new { });
        }

        public  async Task<bool> InsertCuenta(CUENTA cuenta)
        {
            var db = dbConnection();

            var sql = @"

                    INSERT INTO public.""cliente""(id_cta, num_cta, moneda, cedula_cliente , saldo, cod_bancoo)
                    VALUES(@ID_CTA,@NUM_CTA,@MONEDA , @CEDULA_CLIENTE , @SALDO , @COD_BANCO)
                   
                   
                  
                    ";

            var result = await db.ExecuteAsync(sql, new { cuenta.ID_CTA, cuenta.NUM_CTA, cuenta.MONEDA, cuenta.CEDULA_CLIENTE, cuenta.SALDO,cuenta.COD_BANCO });
            return result > 0;
        }

        public async Task<bool> UpdateCuenta(CUENTA cuenta)
        {
            var db = dbConnection();

            var sql = @"

                    UDPATE INTO public.""cuenta""
                    SET id_cta= @ID_CTA ,
                        num_cta= @NUM_CTA ,
                        moneda= @MONEDA ,
                        cedula_cliente=  @CEDULA_CLIENTE,
                        saldo = @SALDO,
                        cod_bancoo =  @COD_BANCO,
                    WHERE cedula= idcedula

                    ";

            var result = await db.ExecuteAsync(sql, new { cuenta.ID_CTA, cuenta.NUM_CTA, cuenta.MONEDA, cuenta.CEDULA_CLIENTE, cuenta.SALDO,cuenta.COD_BANCO });
            return result > 0;
        }
    }
}
