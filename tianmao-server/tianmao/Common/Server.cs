using SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static tianmao.Common.ServerCommands;

namespace tianmao.Common
{
    public class Server
    {
        //Key:SessionID,Value:Socekt
        private static Dictionary<String, SocketAsyncEventArgs> clients;
        //Key:SessionID,Value:Message
        private static Dictionary<String, String> messageQueue;

        public static void Start()
        {
            clients = new Dictionary<string, SocketAsyncEventArgs>();
            messageQueue = new Dictionary<string, string>();
            SocketServer.SocketServer.SetCallBack(CallBack);
            SocketServer.SocketServer.Start();

            Task.Run(() =>
            {
                while (true)
                {
                    SendKeepAlive();
                    Task.Delay(12000).Wait();
                }
            });
        }
        
        public static bool Send<T>(T value, String address)
        {
            return Send(value.GetType().Name, value.ToString(), address);
        }

        public static bool Send(string commandName, string commandValue, string address)
        {
            lock (clients)
            {
                if (!clients.TryGetValue(address, out SocketAsyncEventArgs val)) return false;
                var ok = true;
                try
                {
                    (val.UserToken as AsyncSocketSession).Send(commandName + ":" + commandValue + ";");
                }
                catch (Exception)
                {
                    ok = false;
                }
                if (!ok) { clients.Remove(address); }
                return ok;
            }
        }

        public static void CallBack(SocketAsyncEventArgs ass)
        {
            String str = Encoding.UTF8.GetString(ass.Buffer, ass.Offset, ass.Count);
            Console.Write(str);
            Dictionary<String, String> cmds = new Dictionary<string, string>();
            String[] recevieds = str.Split(';');
            for (int i = 0; i < recevieds.Length; i++)
            {
                var cmd = recevieds[i].Split(':');
                if (cmd.Length == 2)
                {
                    cmds.Add(cmd[0], cmd[1]);
                }
            }

            foreach (KeyValuePair<String, String> cmd in cmds)
            {
                if (cmd.Key == "Close")
                {
                    clients.Remove(cmd.Value);
                }

                if (cmd.Key == "UserId" && !clients.ContainsKey(cmd.Key))
                {
                    clients.Add(cmd.Value, ass);
                    var ok = Send(Session.Success, cmd.Value);
                    if (!ok) { clients.Remove(cmd.Value); }
                }
            }
        }

        public static void SendKeepAlive()
        {
            lock (clients)
            {
                foreach (var client in clients.Keys)
                {
                    try
                    {
                        bool ok = Send(KeepAlive.Keep, client);
                        if (!ok) { clients.Remove(client); }
                    }
                    catch (Exception)
                    {
                        clients.Remove(client);
                    }
                }
            }
        }
    }
}
