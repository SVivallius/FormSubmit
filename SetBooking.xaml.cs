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
    /// Interaction logic for SetBooking.xaml
    /// </summary>
    public partial class SetBooking : Window
    {

        public SetBooking()
        {
            InitializeComponent();
            customerName_txb.Focus();
        }

        private void Finalize(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Booking_btn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
