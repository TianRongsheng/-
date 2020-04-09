using System;
using System.Globalization;

namespace NumberAndDateFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
                    NumberFormatDemo();
                    DateFormatDemo();  
            }  

        public static void NumberFormatDemo()
        {
            int val = 1234567890;
            // culture of the current thread
            Console.WriteLine(val.ToString("N"));
            // use IFormatProvider
            Console.WriteLine(val.ToString("N", new CultureInfo("fr-DZ")));
            // change the culture of the thread
            CultureInfo.CurrentCulture = new CultureInfo("de-DE");
            Console.WriteLine(val.ToString("N"));
        }

        public static void DateFormatDemo()
        {
            var d = new DateTime(2017, 09, 17);
            // current culture
            Console.WriteLine(d.ToString("D"));
            // use IFormatProvider
            Console.WriteLine(d.ToString("D", new CultureInfo("fr-FR")));
            // use current culture
            Console.WriteLine($"{CultureInfo.CurrentCulture}: {d:D}");
            CultureInfo.CurrentCulture = new CultureInfo("es-ES");
            Console.WriteLine($"{CultureInfo.CurrentCulture}: {d:D}");
        }

    }
}
