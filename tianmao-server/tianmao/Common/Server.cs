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
        private static Dictionary<String, AsyncSocketSession> clients;
        //Key:SessionID,Value:Message
        private static Dictionary<String, String> messageQueue;

        public static void Start()
        {
            clients = new Dictionary<string, AsyncSocketSession>();
            messageQueue = new Dictionary<string, string>();
            SocketServer.SocketServer.SetServerNewClientAccepted(NewAccpet);
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

        private static void NewAccpet(Socket client, ISocketSession session)
        {
            var ass = session as AsyncSocketSession;
        }

        public static bool Send<T>(T value, String address)
        {
            return Send(value.GetType().Name, value.ToString(), address);
        }

        public static bool Send(string commandName, string commandValue, string address)
        {
            lock (clients)
            {
                if (!clients.TryGetValue(address, out AsyncSocketSession val)) return false;

                try
                {
                    bool ok = val.Send(commandName + ":" + commandValue + ";");
                    if (!ok) { clients.Remove(address); }
                    return ok;
                }
                catch (Exception)
                {
                    clients.Remove(address);
                }
            }
            return false;
        }

        public static void CallBack(AsyncSocketSession ass, String recevied)
        {
            Console.WriteLine(recevied);
            Dictionary<String, String> cmds = new Dictionary<string, string>();
            String[] recevieds = recevied.Split(';');
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
