using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Models
{
    class Client
    {
        public string Name { get; set; }
        public string BloodGroup { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Rh { get; set; }
    }
}
