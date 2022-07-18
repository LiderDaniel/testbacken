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
    public class TransferenciaRepository : ITransferencia
    {
        private PostgreSQLConfiguration _connectionString;

        public TransferenciaRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteTransferencia(TRANFERENCIA transferencia)
        {
            var db = dbConnection();

            var sql = @"
                    DELETE  
                    FROM public.""transferencias""
                    WHERE id_transaccion =@id_transaccion
                   
                    ";
            var result = await db.ExecuteAsync(sql, new { id_transaccion = transferencia.id_transaccion });
            return result > 0;
        }

        public async Task<IEnumerable<TRANFERENCIA>> GetAllTranferencia()
        {
            var db = dbConnection();
            string sql = @"
            
             SELECT * FROM transferencias
            ";
            var result = await db.QueryAsync<TRANFERENCIA>(sql);

            return result;
        }

        public async Task<TRANFERENCIA> GetTransferenciaDetails(string trans)
        {
            var db = dbConnection();

            var sql = @"
                    SELECT *FROM public.transferencias
                    WHERE id_transaccion = @id_transaccion
                    ";


            return await db.QueryFirstOrDefaultAsync<TRANFERENCIA>(sql, new { id_transaccion = trans });
        }

        public async Task<bool> InsertTransferencia(TRANFERENCIA transferencia)
        {
            var db = dbConnection();

            var sql = @"
                    INSERT INTO public.""transferencias""(id_transaccion,num_cta,cedula_cliente,fecha,monto,estado, num_cuenta_origen ,num_cuenta_destino )
                                                   VALUES(@id_transaccion,@num_cta,@cedula_cliente,@fecha,@monto,@estado,@num_cuenta_origen,@num_cuenta_destino)
 
                    ";

            var resutl = await db.ExecuteAsync(sql, new { transferencia.id_transaccion, transferencia.num_cta, transferencia.cedula_cliente, transferencia.fecha, transferencia.monto, transferencia.estado,transferencia.num_cuenta_origen,transferencia.num_cuenta_destino });
            if (resutl > 0)
            {
                string egresoingresotrans = @" UPDATE cuenta 
                                               set saldo = saldo - @monto
                                                where num_cta = @num_cuenta_origen

        
";
                await db.ExecuteAsync(egresoingresotrans, new { transferencia.monto, transferencia.num_cuenta_origen });

                string ingresodetranfe = @" UPDATE cuenta
                                            set saldo = saldo+ @monto
                                            where num_cta =@num_cuenta_destino 
                                                            
    
                ";
                await db.ExecuteAsync(ingresodetranfe, new { transferencia.monto, transferencia.num_cuenta_destino });
            }
            return resutl > 0;
        }

        public async Task<bool> UpdateTransferencia(TRANFERENCIA transferencia)
        {
            var db = dbConnection();

            string sql = @"
                    UPDATE transferencias
                    SET  num_cta = @num_cta ,
                        cedula_cliente = @cedula_cliente,
                        fecha = @fecha,
                        monto = @monto,
                        estado = @estado,
                        num_cuenta_origen = @num_cuenta_origen,
                        num_cuenta_destino = @num_cuenta_destino
                        
                        
                    WHERE id_transaccion = @id_transaccion";

            var result = await db.ExecuteAsync(sql, new { transferencia.id_transaccion, transferencia.num_cta, transferencia.cedula_cliente, transferencia.fecha, transferencia.monto, transferencia.estado, transferencia.num_cuenta_origen, transferencia.num_cuenta_destino });

            return result > 0;
        }

        public async Task<bool> UpdateTransferenciaID(TRANFERENCIA transferencia)
        {
            var db = dbConnection();

            string sql = @"
                    UPDATE transferencias
                    SET  estado = @estado
                        
                        
                    WHERE id_transaccion = @id_transaccion";


            var result = await db.ExecuteAsync(sql, new { transferencia.estado, transferencia.id_transaccion });

            return result > 0;
        }

        public async Task<TRANFERENCIA> GetAllTranferenciaestado(string id)
        {
            var db = dbConnection();
            string sql = @"

           
            SELECT estado
         FROM transferencias
        WHERE id_transaccion = @id_transaccion;
        
            ";

            return await db.QueryFirstOrDefaultAsync<TRANFERENCIA>(sql, new { id_transaccion = id });
        }

        public async  Task<TRANFERENCIA> GetTransferenciaaHistorialEnviado(string id)
        {
            var db = dbConnection();
            string sql = @"

           
            SELECT num_cuenta_origen
         FROM transferencias
        WHERE num_cuenta_origen = @num_cuenta_origen;
        
            ";

            return await db.QueryFirstOrDefaultAsync<TRANFERENCIA>(sql, new { num_cuenta_origen = id });
        }

        public async Task<TRANFERENCIA> GetTransferenciaaHistorialRecibido(string id)
        {

            var db = dbConnection();
            string sql = @"

           
            SELECT num_cuenta_origen
         FROM transferencias
        WHERE num_cuenta_destino = @num_cuenta_destino;
        
            ";

            return await db.QueryFirstOrDefaultAsync<TRANFERENCIA>(sql, new { num_cuenta_destino = id });
        }
    }


}
    


        
        