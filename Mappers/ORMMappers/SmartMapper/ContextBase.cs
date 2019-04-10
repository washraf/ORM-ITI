using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMapper
{
    public abstract class ContextBase: IDisposable
    {
        protected SqlConnection _connection;
        public ContextBase(string conString)
        {
            _connection = new SqlConnection(conString);
            _connection.Open();
            
        }
        public void Dispose()
        {
         _connection.Dispose();   
        }

    }
}
