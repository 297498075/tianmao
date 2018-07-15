using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using tianmao_client.Service;

namespace tianmao_client
{
    static class Program
    {
        private static SocketState state;
        private static Action stateCallback;

        [STAThread]
        static void Main()
        {
            state = SocketState.Close;
            SocketClient.SocketClient.SetCallback((a) =>
            {
                Console.WriteLine(a);
                var keyValue = a.Split(';');
                for (int i = 0; i < keyValue.Count(); i ++)
                {
                    var val = keyValue[i].Split(':');
                    if(val.Count() == 2)
                    {
                        ServiceSelector(val[0])?.Exec(val[1]);
                    }
                }
            });
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static SocketState State
        {
            get { return state; }
            set
            {
                if (value == SocketState.Connected)
                {
                    bool ok = SocketClient.SocketClient.Start();
                    
                    if(ok) SocketClient.SocketClient.Send("UserId:" + MainForm.Id);
                }
                state = value;

                stateCallback?.Invoke();
            }
        }

        public enum SocketState
        {
            Close,
            Connected
        }

        public static void SetStateChange(Action action)
        {
            stateCallback = action;
        }

        public static IService ServiceSelector(String cmd)
        {
            switch (cmd)
            {
                case "SessionId":
                    return new SessionService();
                case "打开":
                    return new OpenService();
            }
            return null;
        }
    }
}
