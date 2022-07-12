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
    public class ClienteRepository : ICliente
    {

        private PostgreSQLConfiguration _connectionString;


        public ClienteRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public  async Task<bool> DeleteCliente(CLIENTE cliente)
        {
            var db = dbConnection();

            var sql = @"
                    DELETE  
                    FROM public.""cliente""
                    WHERE cedula =@idcedula
                   

                    ";

            var result= await db.ExecuteAsync(sql, new { idcedula =cliente.idcedula});
            return result > 0;
        }

        public async Task<IEnumerable<CLIENTE>> GetAllCliente()
        {
            var db = dbConnection();

            var sql = @"
                    SELECT cedula, tipo_doc, nombre_apellido
                    FROM public.""cliente""

                    ";

            return await db.QueryAsync<CLIENTE>(sql, new {});
        }

        public async Task<CLIENTE> GetClienteDetails(string idcedula)
        {
            var db = dbConnection();

            var sql = @"
                    SELECT cedula, tipo_doc, nombre_apellido
                    FROM public.""cliente""
                    WHERE cedula =@idcedula
                    ";

            return await db.QueryFirstOrDefaultAsync<CLIENTE>(sql, new { });
        }

        public async Task<bool> InsertCliente(CLIENTE cliente)
        {
            var db = dbConnection();

            var sql = @"

                    INSERT INTO public.""cliente""(cedula, tipo_doc, nombre_apellido)
                    VALUES(@idcedula,@tipo_docu,@nombreapellido)
                   
                   
                  
                    ";

            var result =  await db.ExecuteAsync(sql, new { cliente.idcedula, cliente.tipo_docu, cliente.nombreapellido });
            return result > 0;
        }

        public async Task<bool> UpdateCliente(CLIENTE cliente)
        {
            var db = dbConnection();

            var sql = @"

                    UDPATE INTO public.""cliente""
                    SET cedula= @idcedula ,
                        tipo_doc= @tipo_docu ,
                        nombre_apellido= @nombreapellido ,
                    WHERE cedula= @idcedula

                    ";

            var result = await db.ExecuteAsync(sql, new { cliente.idcedula, cliente.tipo_docu, cliente.nombreapellido });
            return result > 0;
        }

       
    }
}
