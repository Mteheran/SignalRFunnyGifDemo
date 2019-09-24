using Microsoft.AspNetCore.SignalR.Client;
using System;
using Xamarin.Forms;

namespace FunnyGif.App
{
    public partial class MainPage : ContentPage
    {
        string IpAndPort { get; set; } = "http://10.0.2.2:5000";

        HubConnection Con { get; set; }

        public MainPage()
        {
            InitializeComponent();          
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {    
                await Con.InvokeAsync("SendMessage", txtValue.Text);

                txtValue.Text = "";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            IpAndPort = txtServer.Text;

            Con = new HubConnectionBuilder().
                                        WithUrl($"{IpAndPort}/message").Build();

            try
            {
                await Con.StartAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error",ex.Message,"OK");
            }      
           
        }
    }
}
