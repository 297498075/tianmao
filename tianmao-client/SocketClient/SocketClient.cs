using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient
{
    public static class SocketClient
    {
        private static Dictionary<String, String> Config;
        private static Action<String> callback;
        private static Socket client;

        public static bool Start()
        {
            try
            {
                using (FileStream fs = new FileStream("SocketClient.json", FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        Config = JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());
                    }
                }
                String host = Config["ip"];

                String port = Config["port"];
                int _port = Convert.ToInt32(port);

                // Get host related information.
                var hostEntry = Dns.GetHostEntry(host);
                // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
                // an exception that occurs when the host IP Address is not compatible with the address family
                // (typical in the IPv6 case).
                foreach (IPAddress address in hostEntry.AddressList)
                {
                    IPEndPoint ipe = new IPEndPoint(address, _port);
                    Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        tempSocket.Connect(ipe);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    if (tempSocket.Connected)
                    {
                        client = tempSocket;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                Task.Run(() =>
                {
                    byte[] buffer = new byte[1024];
                    while (true)
                    {
                        try
                        {
                            client.Receive(buffer);
                        }
                        catch (Exception e)
                        {
                            return;
                        }
                        String recevied = Encoding.UTF8.GetString(buffer);
                        Console.WriteLine(recevied);
                        callback(recevied);
                    }
                });

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void Send(String info)
        {
            client?.Send(Encoding.UTF8.GetBytes(info));
        }

        public static void SetCallback(Action<String> action)
        {
            callback = action;
        }
        
    }
}
