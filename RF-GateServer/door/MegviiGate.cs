﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RF_GateServer.door
{
    class MegviiGate : IGate
    {
        private const string COMMAND_OPEN1 = "on1:01";
        private const string COMMAND_OPEN2 = "on2:01";
        private const string COMMAND_CLOSE = "off1";

        private UdpSocket socket = null;

        public MegviiGate(UdpSocket socket)
        {
            this.socket = socket;
        }

        public void In()
        {
            var buffer = GetOpenPackage(COMMAND_OPEN1);
            Send(buffer);
        }

        public void Out()
        {
            var buffer = GetOpenPackage(COMMAND_OPEN1);
            Send(buffer);
        }

        private void Send(byte[] buffer)
        {
            socket?.Send(buffer);
        }

        private byte[] GetOpenPackage(string command)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(command);
            return buffer;
        }
    }
}
