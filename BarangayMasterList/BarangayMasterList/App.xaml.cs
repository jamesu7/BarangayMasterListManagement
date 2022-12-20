using BarangayMasterList.Services;
using BarangayMasterList.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarangayMasterList
{
    public partial class App : Application
    {
        static VoterService _voterService;
        public static VoterService VoterService
        {
            get
            {
                if(_voterService == null)
                {
                    _voterService = new VoterService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Voter.db3"));
                }
                return _voterService;
            }
        }
        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
