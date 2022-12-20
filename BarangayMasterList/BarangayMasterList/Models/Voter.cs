using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarangayMasterList.Models
{
    public class Voter
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Bday { get; set; }
        public string Gender { get; set; }
        public string PrecintNum { get; set; }
        public string HouseNumber { get; set; }

        public string Name { get { return LastName + ", " + FirstName + ", " + MiddleName; } }

    }
}
