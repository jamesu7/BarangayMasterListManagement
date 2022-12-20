using BarangayMasterList.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BarangayMasterList.ViewModels
{
    public class AddVoterViewModel:BaseVotersViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public AddVoterViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
            VoterInfo = new Voter();
        }
        private async void OnSave()
        {
            var voter = VoterInfo;
            await App.VoterService.AddVoterAsync(voter);
            await Shell.Current.GoToAsync("..");

        }
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
