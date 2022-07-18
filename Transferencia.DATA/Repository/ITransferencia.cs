using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranferencia.MODEL;

namespace Transferencia.DATA.Repository
{
    public  interface ITransferencia 
    {
        Task<IEnumerable<TRANFERENCIA>> GetAllTranferencia();


        Task<TRANFERENCIA> GetAllTranferenciaestado(string id);
        Task<TRANFERENCIA> GetTransferenciaDetails(string id);

        Task<TRANFERENCIA> GetTransferenciaaHistorialEnviado(string id);

        Task<TRANFERENCIA> GetTransferenciaaHistorialRecibido(string id);


        Task<bool> InsertTransferencia(TRANFERENCIA transferencia);

        Task<bool> UpdateTransferencia(TRANFERENCIA transferencia);

        Task<bool> UpdateTransferenciaID(TRANFERENCIA transferencia);

        Task<bool> DeleteTransferencia(TRANFERENCIA transferencia);
    }
}
