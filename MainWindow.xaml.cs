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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bordsbokningar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime _date;
        List<Booking> bookingsToday;
        public MainWindow()
        {
            InitializeComponent();

            _date = new();
            bookingsToday = new();
        }

        private void Date_Selected(object sender, SelectionChangedEventArgs e)
        {
            DatePicker picker = (DatePicker)sender;
            if (picker == null)
            {
                MessageBox.Show($"Värdet i variabeln \"Picker\" var null.\n" +
                $"Avbryter metoden för att förhindra krash.");
                return;
            }

            if (picker.SelectedDate == null)
            {
                MessageBox.Show("Inget datum blev valt!\n" +
                "Avbryter metoden för att förhindra krash.");
                return;
            }


        }
    }
}
