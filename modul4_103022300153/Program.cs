// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using static tpmodul4_103022300153.FanLaptop;

namespace tpmodul4_103022300153
{
    internal class KodeProduk
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

    internal class FanLaptop
    {
        public enum FanState { Quite, Balanced, Performace, Turbo }

        public enum Trigger { modeDown, modeUp, turboShortcut }

        class Transition
        {
             public FanState prevState;
             public FanState nextState;
             public Trigger trigger;

             public Transition(FanState prevState, FanState nextState, Trigger trigger)
             {
                this.prevState = prevState;
                this.nextState = nextState;
                this.trigger = trigger;
             }

            private FanState currentState;

            public void FanLaptop()
            {
                currentState = FanState.Quite;
            }

            public static List<Transition> transitions = new List<Transition>
            {
                new Transition(FanState.Quite, FanState.Balanced, Trigger.modeUp),
                new Transition(FanState.Quite, FanState.Turbo, Trigger.turboShortcut),
                new Transition(FanState.Balanced, FanState.Quite, Trigger.modeDown),
                new Transition(FanState.Balanced, FanState.Performace, Trigger.modeUp),
                new Transition(FanState.Performace, FanState.Balanced, Trigger.modeDown),
                new Transition(FanState.Performace, FanState.Turbo, Trigger.modeUp),
                new Transition(FanState.Turbo, FanState.Performace, Trigger.modeDown),
                new Transition(FanState.Turbo, FanState.Quite, Trigger.turboShortcut)
            };

            private FanState GetNextState(FanState prevState, Trigger trigger)
            {
                foreach (var transition in transitions)
                {
                    if (transition.prevState == prevState && transition.trigger == trigger)
                    {
                        return transition.currentState;
                    }
                }
                return prevState;
            }

            public void ActiveTrigger(Trigger trigger)
            {
                FanState nextState = GetNextState(currentState, trigger);
                if (nextState != currentState)
                {
                    currentState = nextState; 
                    Console.WriteLine(nextState == FanState.Quite ? "Fan Quite berubah menjadi Turbo") : "Fan Quite berubah menjadi Balanced");
                }
            }

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

            FanLaptop fan = new FanLaptop();
            while (true)
            {
                Console.WriteLine("Masukkan perintah (modeDown / modeUp / turboShortcut): ");
                string input = Console.ReadLine().ToLower();

                if (input == "modeDown")
                {
                    fan.ActiveTrigger(Trigger.modeDown);
                }
                else if (input == "modeUp")
                {
                    fan.ActiveTrigger(Trigger.modeUp);
                }

            }
        }
    }
}