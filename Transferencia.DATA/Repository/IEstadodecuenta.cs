using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranferencia.MODEL;

namespace Transferencia.DATA.Repository
{
    public interface IEstadodecuenta
    {

        Task<IEnumerable<EstadoDeCuenta>> GetAllEstadoCuenta();

        Task<EstadoDeCuenta> GetEstadoCuentaDetails(string id);

        Task<bool> InsertEstadoCuenta(EstadoDeCuenta cuenta);

        Task<bool> UpdateEstadoCuenta(EstadoDeCuenta cuenta);
        Task<bool> DeleteEstadoCuenta(EstadoDeCuenta cuenta);
    }
}
