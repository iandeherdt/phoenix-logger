using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoenixLogger.Console1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var host = "ws://localhost:4000/socket";
            var socket = new Utils.Socket(host,
                logger: (kind, msg, data) => Console.WriteLine($"{kind}: {msg}, \n" + JsonConvert.SerializeObject(data)));

            Task.Run(() => socket.Connect());

            var channel = socket.Channel("application:console1");
            channel.On("new_msg", msg =>
            {
                Console.WriteLine("New message: " + JsonConvert.SerializeObject(msg));
            });
            channel.Join();

            Thread.Sleep(1000);

            channel.Leave();

            Thread.Sleep(1000);

            channel = socket.Channel("application:console1");
            channel.On("new_msg", msg =>
            {
                Console.WriteLine("New message: " + msg.body);
            });
            channel.Join();

            var message = "";

            while (message?.Trim() != "q")
            {
                message = Console.ReadLine();
                channel.Push("new_msg", new { body = message });
            }

            channel.Leave();
            socket.Disconnect(null);
        }
    }
}
