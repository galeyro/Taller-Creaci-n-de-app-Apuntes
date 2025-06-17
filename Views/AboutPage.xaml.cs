using Microsoft.Maui.Controls;
using System;
using Microsoft.Maui.ApplicationModel;

namespace GuevaraGCreacionAppApuntes.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void LearnMore_Clicked(object sender, EventArgs e)
        {
            await Launcher.Default.OpenAsync("https://aka.ms/maui");
        }
    }
}