using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Database
{
    public interface ISqlCommandWrapper
    {
        int ExecuteScalar();
    }
}
