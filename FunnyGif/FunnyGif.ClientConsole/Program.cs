using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace FunnyGif.ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HubConnection con = new HubConnectionBuilder().
                                       WithUrl("http://172.16.28.47:5000/message").Build();

            con.StartAsync().Wait();

            while (true)
            {
                string message = Console.ReadLine();
                con.InvokeAsync("SendMessage", message).Wait();
            }            
        }
    }
}
