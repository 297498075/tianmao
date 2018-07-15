using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tianmao.Common
{
    public class ServerCommands
    {
        public enum Session
        {
            Success,
            InSuccess,
            Error
        }

        public enum KeepAlive
        {
            Keep
        }
    }
}
