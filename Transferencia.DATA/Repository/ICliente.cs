using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranferencia.MODEL;

namespace Transferencia.DATA.Repository
{
    public interface ICliente 
       {
        Task<IEnumerable<CLIENTE>> GetAllCliente();
    
        Task<CLIENTE> GetClienteDetails(string id);

        Task<bool> InsertCliente(CLIENTE cliente);

        Task<bool> UpdateCliente(CLIENTE cliente);
        Task<bool> DeleteCliente(CLIENTE cliente);
    }
}
