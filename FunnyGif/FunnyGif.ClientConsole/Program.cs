using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace FunnyGif.ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(5000);
            HubConnection con = new HubConnectionBuilder().
                                       WithUrl("http://localhost:5000/message").Build();

            con.StartAsync().Wait();

            while (true)
            {
                string message = Console.ReadLine();
                con.InvokeAsync("SendMessage", message).Wait();
            }            
        }
    }
}
