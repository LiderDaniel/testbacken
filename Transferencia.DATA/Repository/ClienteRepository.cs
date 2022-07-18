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
                    WHERE cedula =@cedula
                   

                    ";

            var result= await db.ExecuteAsync(sql, new { cedula =cliente.cedula});
            return result > 0;
        }

        public async Task<IEnumerable<CLIENTE>> GetAllCliente()
        {

            var db = dbConnection();

            string sql = @"
            
             SELECT * FROM cliente";

           var result = await db.QueryAsync<CLIENTE>(sql, new {});

            return result;

        }

        public async Task<CLIENTE> GetClienteDetails(string idcedula)
        {
            var db = dbConnection();

            var sql = @"
                    SELECT * FROM public.cliente
                    WHERE cedula =@cedula
                    ";

            return await db.QueryFirstOrDefaultAsync<CLIENTE>(sql, new {cedula = idcedula });
        }

        public async Task<bool> InsertCliente(CLIENTE cliente)
        {
            var db = dbConnection();

            var sql = @"

                    INSERT INTO public.""cliente""(cedula, tipo_doc, nombre_apellido)
                    VALUES(@cedula,@tipo_doc,@nombre_apellido)
                   
                   
                  
                    ";

            var result =  await db.ExecuteAsync(sql, new { cliente.cedula, cliente.tipo_doc, cliente.nombre_apellido });
            return result > 0;
        }

        public async Task<bool> UpdateCliente(CLIENTE cliente)
        {
            var db = dbConnection();

            var sql = @"

        
                    UPDATE cliente
                    SET   cedula= @cedula ,
                        tipo_doc= @tipo_doc ,
                        nombre_apellido= @nombre_apellido 
                    WHERE cedula= @cedula

            ";

            var result = await db.ExecuteAsync(sql, new { cliente.cedula, cliente.tipo_doc, cliente.nombre_apellido });
            return result > 0;
        }

       
    }
}
