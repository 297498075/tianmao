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
                
                var hostEntry = Dns.GetHostEntry(host);
                foreach (IPAddress address in hostEntry.AddressList)
                {
                    IPEndPoint ipe = new IPEndPoint(address, _port);
                    Socket tempSocket = new Socket(ipe.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);
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
                    byte[] buffer = null;
                    List<byte> builder = new List<byte>();

                    while (true)
                    {
                        Recvie(buffer,builder);

                        var str = Encoding.UTF8.GetString(builder.ToArray())
                                .Replace(sEndCode, String.Empty);

                        if (String.IsNullOrEmpty(str))
                        {
                            return;
                        }

                        callback(str);

                        builder.Clear();
                    }
                });

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
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

        private static char cEndCode = '\0';
        private static String sEndCode = cEndCode.ToString();
        private static byte bEndCode = Encoding.UTF8.GetBytes(new char[] { cEndCode })[0];
        public static void Recvie(byte[] buffer, List<byte> builder)
        {
            try
            {
                buffer = new byte[8];
                client.Receive(buffer);
                builder.AddRange(buffer);
                if (buffer[7] != (bEndCode))
                {
                    Recvie(buffer, builder);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return;
            }
        }
    }
}
