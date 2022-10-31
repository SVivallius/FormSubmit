using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bordsbokningar.Classes
{
    public static class FileManager
    {
        static public void Load(List<Booking> bookings)
        {
            string path = @"bookings.dat";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string readLine = sr.ReadLine();
                        if (readLine == null)
                        {
                            MessageBox.Show("Läsning av fil misslyckades!\n" +
                                "Avbryter inläsning för att förhindra krash.");
                            return;
                        }

                        string[] split = readLine.Split(new string[] { "&//" }, StringSplitOptions.None);

                        string name = split[0];
                        int table = int.Parse(split[1]);
                        DateTime bookedAt = DateTime.Parse(split[2]);

                        bookings.Add(new Booking(table, name, bookedAt));
                    }
                    sr.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        static public async void Save(List<Booking> bookings)
        {
            await using (FileStream fs = new FileStream(@"bookings.dat", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (Booking booking in bookings)
                    {
                        await sw.WriteLineAsync(booking.ToFile());
                    }
                    sw.Close();
                }
                fs.Dispose();
            }
        }
    }
}
