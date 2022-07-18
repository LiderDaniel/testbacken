using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranferencia.MODEL;

namespace Transferencia.DATA.Repository
{
    public interface IBanco
    {
                                
        Task<IEnumerable<BANCO>> GetAllBanco();

        Task<BANCO> GetBancoDetails(string id);

        Task<bool> InsertBanco(BANCO banco);

        Task<bool> UpdateBanco(BANCO banco);
        Task<bool> DeleteBanco(BANCO banco);
    }
}
