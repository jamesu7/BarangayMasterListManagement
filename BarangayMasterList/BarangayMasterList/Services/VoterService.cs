using Acr.UserDialogs;
using BarangayMasterList.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarangayMasterList.Services
{
    public class VoterService : IVoterRepository
    {
        public SQLiteAsyncConnection _database;

        public VoterService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Voter>().Wait();
        }
        public async Task<bool> AddVoterAsync(Voter voterInfo)
        {
            if (voterInfo.Id > 0)
            {
                await _database.UpdateAsync(voterInfo);
                await App.Current.MainPage.DisplayAlert(null, "Voter's detail has been updated.", "OK");
            }
            else
            {
                await _database.InsertAsync(voterInfo);
                await App.Current.MainPage.DisplayAlert(null, "New Voter has been saved.", "OK");
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteVoterAsync(int id)
        {
            await _database.DeleteAsync<Voter>(id);
            return await Task.FromResult(true);
        }

        public async Task<Voter> GetVoterAsync(int id)
        {
            return await _database.Table<Voter>().Where(x=>x.Id==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Voter>> GetVoterAsync()
        {
            return await Task.FromResult(await _database.Table<Voter>().OrderBy(x=>x.LastName).ToListAsync());
        }

        public Task<bool> UpdateVoterAsync(Voter voter)
        {
            throw new NotImplementedException();
        }
    }
}
