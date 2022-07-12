using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranferencia.MODEL;

namespace Transferencia.DATA.Repository
{
    public interface ICuenta
    {
        Task<IEnumerable<CUENTA>> GetAllCuenta();

        Task<CUENTA> GetCuentaDetails(string id);

        Task<bool> InsertCuenta(CUENTA cuenta);

        Task<bool> UpdateCuenta(CUENTA cuenta);
        Task<bool> DeleteCuenta(CUENTA cuenta);
    }
}
