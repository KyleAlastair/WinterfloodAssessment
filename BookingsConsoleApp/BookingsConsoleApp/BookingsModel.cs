using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingsConsoleApp
{
    public class BookingsModel
    {
        public int BookingId { get; set; }
        public string NameOfPersonBooking { get; set; }
        public string DateOfBooking { get; set; } 
        public string BookingService { get; set; }

    }
}
