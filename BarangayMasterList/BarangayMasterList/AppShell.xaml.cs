using BarangayMasterList.ViewModels;
using BarangayMasterList.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BarangayMasterList
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddVoterPage), typeof(AddVoterPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
