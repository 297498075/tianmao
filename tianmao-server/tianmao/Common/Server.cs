using SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            var task = Task.Run(() =>
            {
                foreach (var client in clients)
                {
                    try
                    {
                        Send("KeepAlive", "1", client.Value.SessionID);
                    }
                    catch (Exception)
                    {
                        clients.Remove(client.Value.SessionID);
                    }
                }
                Thread.Sleep(5000);
            });
        }

        private static void NewAccpet(Socket client, ISocketSession session)
        {
            var ass = session as AsyncSocketSession;
            String content = "SessionId:" + ass.SessionID + ";";
            ass.Send(content + content.Length);
            clients.Remove(ass.SessionID);
            clients.Add(ass.SessionID, ass);
        }

        public static void Send(String key, String value, String address)
        {
            if (clients.ContainsKey(address))
            {
                try
                {
                    clients[address].Send(key + ":" + value + ";");
                }
                catch (Exception)
                {
                    clients.Remove(address);
                }
            }
        }

        public static void CallBack(String recevied)
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
            }
        }
    }
}
