using SocketServer;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SocketServer
{
    public class SocketServer
    {
        private static Action<String> _receiveCallback;
        private static Action<Socket, ISocketSession> _newAcceptedCallback;
        private static SocketServerBase server;

        public static void Start()
        {
            server = new SocketServerBase();
            server.NewClientAccepted += Server_NewClientAccepted;
            server.Start();
        }

        private static void Server_NewClientAccepted(Socket client, ISocketSession session)
        {
            AsyncSocketSession ass = session as AsyncSocketSession;
            ass.SetReceiveHandler(arg =>
            {
                string received = Encoding.UTF8.GetString(arg.Buffer, arg.Offset, arg.BytesTransferred);
                _receiveCallback?.Invoke(received);
            });
            _newAcceptedCallback(client, session);
        }

        public static void SetCallBack(Action<String> func)
        {
            _receiveCallback = func;
        }

        public static void SetServerNewClientAccepted(Action<Socket, ISocketSession> action)
        {
            _newAcceptedCallback = action;
        }

    }
}
