using BarangayMasterList.Models;
using BarangayMasterList.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarangayMasterList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVoterPage : ContentPage
    {
        public Voter VoterInfo { get; set; }
        public AddVoterPage()
        {
            InitializeComponent();
            BindingContext = new AddVoterViewModel();
        }
        public AddVoterPage(Voter voter)
        {
            InitializeComponent();
            BindingContext = new AddVoterViewModel();
            if (voter != null)
            {
                ((AddVoterViewModel)BindingContext).VoterInfo = voter;
            }
        }

    }
}