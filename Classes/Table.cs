using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bordsbokningar.Classes
{
    public class Booking
    {
        public int table { get; set; }
        public string customer { get; set; }
        public DateTime bookedAt { get; set; }

        public Booking(int table, string customer, DateTime bookedAt)
        {
            this.table = table;
            this.customer = customer;
            this.bookedAt = bookedAt;
        }

        public override string ToString()
        {
            return $"{this.customer} har bokat bord Nr.{this.table} " +
                $"på datumet {bookedAt.Day}-{bookedAt.Month}-{bookedAt.Year}, " +
                $"klockan {bookedAt.Hour}:00.";
        }

        public string ToFile()
        {
            return customer + "&//" + table + "&//" + bookedAt.ToString();
        }
    }
}
