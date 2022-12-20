using Acr.UserDialogs;
using BarangayMasterList.Models;
using BarangayMasterList.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BarangayMasterList.ViewModels
{
    public class VotersViewModel : BaseVotersViewModel
    {
        public Command LoadVoterCommand { get; }
        public ObservableCollection<Voter> VoterInfos { get;}
        public Command AddVoterCommand { get; }
        public Command VoterTappedEdit { get; }
        public Command VoterTappedDelete { get; }
        public Command ClearVoterCommand { get; }
        public VotersViewModel(INavigation _navigation)
        {
            LoadVoterCommand = new Command(async()=> await ExecuteLoadVoterCommand());
            VoterInfos = new ObservableCollection<Voter>();
            AddVoterCommand = new Command(OnAddVoter);
            VoterTappedEdit = new Command<Voter>(OnEditVoter);
            VoterTappedDelete = new Command<Voter>(OnDeleteVoter);
            ClearVoterCommand = new Command(OnClearVoter);
            Navigation=_navigation;
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadVoterCommand()
        { 
            IsBusy = true;
            UserDialogs.Instance.ShowLoading("Loading...");
            try
            {
                VoterInfos.Clear();
                var voterList = await App.VoterService.GetVoterAsync();
                foreach (var voter in voterList)
                {
                    VoterInfos.Add(voter);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;   
            }
            UserDialogs.Instance.HideLoading();
        }
    
        private async void OnAddVoter(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddVoterPage));
        }
        private async void OnEditVoter(Voter voter)
        {
            await Navigation.PushAsync(new AddVoterPage(voter));
        }
        private async void OnDeleteVoter(Voter voter)
        {
            if(voter == null)
            {
                return;
            }
            await App.VoterService.DeleteVoterAsync(voter.Id);
            await ExecuteLoadVoterCommand();
        }
        private void OnClearVoter()
        {
            VoterInfos.Clear();
        }
    }
}