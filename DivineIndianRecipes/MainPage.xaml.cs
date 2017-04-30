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
    public partial class MainPage : PhoneApplicationPage
    {
        bool load_def = false;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            

            String str = "0";
            int num;
            bool stat = false;
            IsolatedStorageFile myspace = IsolatedStorageFile.GetUserStoreForApplication();
            String tem = "a";
            try
            {
                using (var isoFileStream = new IsolatedStorageFileStream("number.txt", FileMode.Open, myspace))
                {
                    using (var isoFileReader = new StreamReader(isoFileStream))
                    {
                        str = isoFileReader.ReadToEnd();
                        String[] temp = str.Split('.');
                        num = Convert.ToInt32(temp[0]);
                        if (temp[1].Equals("1"))
                            stat = true;
                        tem = temp[1];
                    }
                }

            }
            catch
            {
                num = 0;
            }
            if (num == 0)
                load_def = true;
            if (!stat)
                if (num % 5 == 0 && num != 0)
                {
                    MessageBoxResult res = MessageBox.Show("You have used Divine Indian Recipes " + num + " times. Rate and Review us to help us improve.", "Divine Indian Recipes", MessageBoxButton.OKCancel);
                    if (res == MessageBoxResult.OK)
                    {
                        MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
                        marketplaceReviewTask.Show();
                        stat = true;
                    }
                    else if (res == MessageBoxResult.Cancel && num == 5)
                    {
                        MessageBoxResult res1 = MessageBox.Show("Do you want to send feedback?", "Divine Indian Recipes", MessageBoxButton.OKCancel);
                        if (res1 == MessageBoxResult.OK)
                        {
                            EmailComposeTask emailTask = new EmailComposeTask();
                            emailTask.Subject = "Feedback for app: Divine Indian Recipes";
                            emailTask.To = "bharatgoyal@outlook.com";
                            emailTask.Show();
                        }
                    }


                }
            num++;
            String write;
            if (stat)
                write = num + ".1";
            else
                write = num + ".0";
            using (var isoFileStream = new IsolatedStorageFileStream("number.txt", FileMode.OpenOrCreate, myspace))
            {
                using (var isoFileWriter = new StreamWriter(isoFileStream))
                {
                    isoFileWriter.WriteLine(write);
                }
            }

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailTask = new EmailComposeTask();
            emailTask.Subject = "Feedback for app: Divine Indian Recipes";
            emailTask.To = "bharatgoyal@outlook.com";
            emailTask.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/aboutus.xaml", UriKind.Relative));
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}