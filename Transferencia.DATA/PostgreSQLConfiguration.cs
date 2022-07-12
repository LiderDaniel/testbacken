using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferencia.DATA
{
    public class PostgreSQLConfiguration
    {

      
        public PostgreSQLConfiguration(string connectionStrig) => ConnectionString = connectionStrig;

        public string ConnectionString { get; set; }
    }
 }

