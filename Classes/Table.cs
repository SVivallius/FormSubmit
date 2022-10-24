using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bordsbokningar.Classes
{
    internal abstract class Table
    {
        List<Booking> bookings;
    }

    class Table_1 : Table
    {
        public Table_1()
        {

        }
    }

    class Booking
    {
        string customerName { get; set; }
        DateTime bookedAt { get; set; }
        public Booking(DateTime dt, string customerName)
        {
            this.customerName = customerName;
            bookedAt = dt;
        }
    }
}
