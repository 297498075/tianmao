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
            SocketServer.SocketServer.Start();
        }

        private static void NewAccpet(Socket client, ISocketSession session)
        {
            var ass = session as AsyncSocketSession;
            ass.Send("SessionId:" + ass.SessionID + ";");
            clients.Remove(ass.SessionID);
            clients.Add(ass.SessionID, ass);
        }

        public static void Send(String content, String address)
        {
            if (messageQueue.ContainsKey(address))
            {
                var response = messageQueue[address];
                messageQueue.Remove(address);
                clients[address].Send(response);
            }
        }
    }
}
