using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tianmao_client.Service
{
    public class CloseService : BaseService
    {
        public override bool Exec(string query)
        {
            base.Exec(query);

            if(query == "电脑")
            {
                Process.Start("cmd.exe","shutdown -s -t 10");
            }

            return true;
        }
    }
}
