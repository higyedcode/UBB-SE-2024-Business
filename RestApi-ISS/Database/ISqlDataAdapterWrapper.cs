using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

namespace Iss.Database
{
    public interface ISqlDataAdapterWrapper
    {
        void InsertCommand(SqlCommand command);
        void Fill(DataSet dataSet);
        void ExecuteNonQuery(SqlCommand command);
        public void SelectCommand(SqlCommand command);
    }
}
