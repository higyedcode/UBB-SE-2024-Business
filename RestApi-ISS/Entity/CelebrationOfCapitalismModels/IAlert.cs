using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public interface IAlert
    {
        int Id { get; set; }
        int UserId { get; set; }
        void Notify();
    }
}
