using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tianmao_client.Service
{
    public class BaseService : IService
    {
        public virtual bool Exec(string query)
        {
            return true;
        }
    }
}
