using Bordsbokningar.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bordsbokningar
{
    /// <summary>
    /// Interaction logic for ShowBookings.xaml
    /// </summary>
    public partial class ShowBookings : Window
    {
        public List<Booking> thisBookings;
        public bool unBookedSomething;

        public ShowBookings(List<Booking> list)
        {
            InitializeComponent();
            unBookedSomething = false;

            thisBookings = list;
            foreach (Booking booking in thisBookings)
            {
                bookings_lbx.Items.Add(booking.ToString());
            }
        }

        private void Close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void unBook_btn_Click(object sender, RoutedEventArgs e)
        {
            int selection = bookings_lbx.SelectedIndex;
            bookings_lbx.Items.RemoveAt(selection);
            thisBookings.RemoveAt(selection);
            unBookedSomething = true;
        }
    }
}
