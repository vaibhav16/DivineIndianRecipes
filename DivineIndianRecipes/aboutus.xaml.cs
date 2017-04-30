using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
using DivineIndianRecipes.Resources;

namespace DivineIndianRecipes
{
    public partial class aboutus : PhoneApplicationPage
    {
        public aboutus()
        {
            InitializeComponent();
        }
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailTask = new EmailComposeTask();
            emailTask.Subject = "Feedback for app: Divine Indian Recipes";
            emailTask.To = "bharatgoyal@outlook.com";
            emailTask.Show();
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/aboutus.xaml", UriKind.Relative));
        }

        private void HomeApplicationBar_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}