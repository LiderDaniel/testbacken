using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranferencia.MODEL
{
    public class TRANFERENCIA
    {
        public string id_transaccion { get; set; }

        public string num_cta { get; set; }

        public string cedula_cliente { get; set; }

        public DateTime fecha { get; set; }

        
        public int  monto { get; set; }
 

        public string estado { get; set; }


        public string num_cuenta_destino { get; set; }

        public string banco_origen { get; set; }

        public string banco_destino { get; set; }

    }
}
