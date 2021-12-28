using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class patient
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public int age { get; set; }
       // public string date { get; set; }


        //public virtual IEnumerable<booking> Bookings { get; set; }

       // public virtual IEnumerable<prescribe_1> Prescribes { get; set; }
    }
}
