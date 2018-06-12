using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tianmao_client.Service
{
    public interface IService
    {
        bool Exec(String query);
    }
}
