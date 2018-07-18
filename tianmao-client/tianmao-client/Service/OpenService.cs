using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tianmao_client.Service
{
    public class OpenService : BaseService
    {
        public override bool Exec(string query)
        {
            String path = SelectPath(query);

            if (!String.IsNullOrEmpty(path))
            {
                var arr = path.Split('\0');
                Process.Start(arr[0], arr[1]);
            }

            return true;
        }

        private string SelectPath(string query)
        {
            return PathForm.paths.ContainsKey(query) ? PathForm.paths[query] : null;
        }
    }
}
