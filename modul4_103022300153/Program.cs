// See https://aka.ms/new-console-template for more information
namespace tpmodul4_103022300153
{
    class KodeProduk
    {
        public enum Elektronik
        {
            Laptop,
            Smartphone,
            Tablet,
            Headset,
            Keyboard,
            Mouse,
            Printer,
            Monitor,
            Smartwatch,
            Kamera
        }

        private static string[] kodeElektronik = { "E100", "E101", "E102", "E103", "E104", "E105", "E105", "E106", "E107", "E108", "E109" };

        public static string GetKodeElektronik(Elektronik elektronik)
        {
            return kodeElektronik[(int)elektronik];
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Elektronik  " + " Kode Elektronik");
            Console.WriteLine("Laptop       " + KodeProduk.GetKodeElektronik(KodeProduk.Elektronik.Laptop));
            Console.WriteLine("Smartphone   " + KodeProduk.GetKodeElektronik(KodeProduk.Elektronik.Smartphone));
            Console.WriteLine("Tablet       " + KodeProduk.GetKodeElektronik(KodeProduk.Elektronik.Tablet));
            Console.WriteLine("Headset      " + KodeProduk.GetKodeElektronik(KodeProduk.Elektronik.Headset));
            Console.WriteLine("Keyboard     " + KodeProduk.GetKodeElektronik(KodeProduk.Elektronik.Keyboard));
            Console.WriteLine("Mouse        " + KodeProduk.GetKodeElektronik(KodeProduk.Elektronik.Mouse));
            Console.WriteLine("Printer      " + KodeProduk.GetKodeElektronik(KodeProduk.Elektronik.Printer));
            Console.WriteLine("Monitor      " + KodeProduk.GetKodeElektronik(KodeProduk.Elektronik.Monitor));
            Console.WriteLine("Smartwatch   " + KodeProduk.GetKodeElektronik(KodeProduk.Elektronik.Smartwatch));
            Console.WriteLine("Kamera       " + KodeProduk.GetKodeElektronik(KodeProduk.Elektronik.Kamera));
            Console.WriteLine("");
        }
    }
}