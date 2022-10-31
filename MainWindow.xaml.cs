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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bordsbokningar.Classes;

namespace Bordsbokningar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DateTime bookingDate;
        public List<Booking> bookings;

        public MainWindow()
        {
            InitializeComponent();

            bookingDate = new DateTime();
            bookings = new List<Booking>();
            FileManager.Load(bookings);
        }

        private void Date_Selected(object sender, SelectionChangedEventArgs e)
        {
            DatePicker picker = (DatePicker)sender;
            if (picker == null)
            {
                MessageBox.Show("Värdet i variabeln \"Picker\" var null.\n" +
                "Avbryter metoden för att förhindra krash.");
                return;
            }

            if (picker.SelectedDate == null)
            {
                MessageBox.Show("Inget datum blev valt!\n" +
                "Avbryter metoden för att förhindra krash.");
                return;
            }
            
            if (picker.SelectedDate < DateTime.Now)
            {
                MessageBox.Show("Du kan inte ange ett redan passerat datum!\n" +
                    "Avbryter val.");
                return;
            }

            bookingDate = (DateTime)picker.SelectedDate;
            SetAvailable(bookings);
        }

        private void PickBooking(object sender, RoutedEventArgs e)
        {
            // Setting up data gathering

            SetBooking setBooking = new();
            setBooking.ShowDialog();
            if (setBooking.DialogResult == false) return;

            string customerName = setBooking.customerName_txb.Text;

            Button recieved = (Button)sender;
            string preSplit = recieved.Name;


            // Save gathered data.
            string[] split = preSplit.Split(new string[] { "_"}, StringSplitOptions.RemoveEmptyEntries);
            bool parse = Int32.TryParse(split[1], out int hour);

            
            if (!parse)
            {
                MessageBox.Show("Konversionen till heltal av bokningstiden misslyckades!\n" +
                "Avbryter metod för att förhindra krash.");
                return;
            }

            DateTime dt = new();
            dt = bookingDate.AddHours(hour);
            switch (split[0].ToLower())
            {
                case "table1": bookings.Add(new Booking(1, customerName, dt)); break;
                case "table2": bookings.Add(new Booking(2, customerName, dt)); break;
                case "table3": bookings.Add(new Booking(3, customerName, dt)); break;
                case "table4": bookings.Add(new Booking(4, customerName, dt)); break;
                case "table5": bookings.Add(new Booking(5, customerName, dt)); break;
            }
            FileManager.Save(bookings);
            SetAvailable(bookings);
        }

        public void SetAvailable(List<Booking> list)
        {
            ResetButtons();

            var queryBookings = list
                .Where(booking => booking.bookedAt.Year == bookingDate.Year)
                .Where(booking => booking.bookedAt.Month == bookingDate.Month)
                .Where(booking => booking.bookedAt.Day == bookingDate.Day)
                .Select(booking => booking);

            foreach(Booking booking in queryBookings)
            {
                switch (booking.bookedAt.Hour)
                {
                    case 16:
                        switch (booking.table)
                        {
                            case 1: Table1_16_btn.IsEnabled = false; break;
                            case 2: Table2_16_btn.IsEnabled = false; break;
                            case 3: Table3_16_btn.IsEnabled = false; break;
                            case 4: Table4_16_btn.IsEnabled = false; break;
                            case 5: Table5_16_btn.IsEnabled = false; break;
                        }
                        break;

                    case 18:
                        switch (booking.table)
                        {
                            case 1: Table1_18_btn.IsEnabled = false; break;
                            case 2: Table2_18_btn.IsEnabled = false; break;
                            case 3: Table3_18_btn.IsEnabled = false; break;
                            case 4: Table4_18_btn.IsEnabled = false; break;
                            case 5: Table5_18_btn.IsEnabled = false; break;
                        }
                        break;

                    case 20:
                        switch (booking.table)
                        {
                            case 1: Table1_20_btn.IsEnabled = false; break;
                            case 2: Table2_20_btn.IsEnabled = false; break;
                            case 3: Table3_20_btn.IsEnabled = false; break;
                            case 4: Table4_20_btn.IsEnabled = false; break;
                            case 5: Table5_20_btn.IsEnabled = false; break;
                        }
                        break;
                }
            }
        }

        public void ResetButtons()
        {
            Table1_16_btn.IsEnabled = true;
            Table2_16_btn.IsEnabled = true;
            Table3_16_btn.IsEnabled = true;
            Table4_16_btn.IsEnabled = true;
            Table5_16_btn.IsEnabled = true;

            Table1_18_btn.IsEnabled = true;
            Table2_18_btn.IsEnabled = true;
            Table3_18_btn.IsEnabled = true;
            Table4_18_btn.IsEnabled = true;
            Table5_18_btn.IsEnabled = true;

            Table1_20_btn.IsEnabled = true;
            Table2_20_btn.IsEnabled = true;
            Table3_20_btn.IsEnabled = true;
            Table4_20_btn.IsEnabled = true;
            Table5_20_btn.IsEnabled = true;
        }

        private void DisplayBookings_Click(object sender, RoutedEventArgs e)
        {
            ShowBookings show = new ShowBookings(bookings);
            show.ShowDialog();

            if (show.thisBookings.Count < bookings.Count)
            {
                bookings.Clear();
                bookings.AddRange(show.thisBookings);

                FileManager.Save(bookings);
                SetAvailable(bookings);
            }
        }
    }
}
