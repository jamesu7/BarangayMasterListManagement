using BarangayMasterList.Models;
using BarangayMasterList.ViewModels;
using SQLite;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;

namespace BarangayMasterList.Views
{
    public partial class VotersPage : ContentPage
    {
        VotersViewModel _viewModel;
        private ListView _listView;
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public VotersPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new VotersViewModel(Navigation);

            var db = new SQLiteConnection(dbPath);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}