using BarangayMasterList.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarangayMasterList.Services
{
    public interface IVoterRepository
    {
        Task<bool> AddVoterAsync(Voter voter);
        Task<bool> UpdateVoterAsync(Voter voter);
        Task<bool> DeleteVoterAsync(int id);
        Task<Voter> GetVoterAsync(int id);
        Task<IEnumerable<Voter>> GetVoterAsync();
    }
}
