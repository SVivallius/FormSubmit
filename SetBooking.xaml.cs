﻿using System;
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
            if (VerifyInput()) this.DialogResult = true;
        }

        private void Cancel_Booking_btn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void customerName_txb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && VerifyInput())
            {
                this.DialogResult = true;
            }
            if (e.Key == Key.Escape)
            {
                this.DialogResult = false;
                return;
            }
        }

        private bool VerifyInput()
        {
            if (this.customerName_txb.Text.Length == 0)
            {
                MessageBox.Show("Fältet \"Namn\" kan inte vara tomt!");
                return false;
            }
            return true;
        }
    }
}
