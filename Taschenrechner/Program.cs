using System;

namespace Taschenrechner
{
    delegate void rechenoperation();



    class Program
    {
        static void Main(string[] args)
        {
            var T = new Taschenrechner();
            while (true)
            {
                T.EingabeRechenaufgabe();
                T.BerechneRechenaufgabe();
                T.AusgabeRechenergenis();
            }
        }
    }



    class Taschenrechner
    {
        private Ergebnis Ergebnis;
        private Rechenaufgabe Aufgabe;
        private rechenoperation Operation;

        public Taschenrechner()
        {
            Ergebnis = new Ergebnis();
            Aufgabe = new Rechenaufgabe();
            Operation = null;
        }

        public void EingabeRechenaufgabe()
        {
            Aufgabe.EmpfangeAufgabe(Console.ReadLine());
        }

        public void BerechneRechenaufgabe()
        {
            switch (Aufgabe.Operation)
            {
                case '+': Operation = Addieren; break;
                case '-': Operation = Subtrahieren; break;
                case '*': Operation = Multiplizieren; break;
                case '/': Operation = Dividieren; break;
                case '^': Operation = Potenzieren; break;
                default: Operation = null; break;
            }
            if (Operation != null && Aufgabe.OK)
            {
                Operation();
            }
        }

        public void AusgabeRechenergenis()
        {
            if (!Aufgabe.OK || !Ergebnis.Erfolg)
            {
                Console.WriteLine("Fehleingabe");
                return;
            }
            Console.WriteLine(Aufgabe.Aufgabe + " = " + Ergebnis.Wert);
        }

        private void Addieren()
        {
            if (Aufgabe.OK)
            {
                Ergebnis.Wert = Aufgabe.WertA + Aufgabe.WertB;
                Ergebnis.Erfolg = true;
            }
        }

        private void Subtrahieren()
        {
            if (Aufgabe.OK)
            {
                Ergebnis.Wert = Aufgabe.WertA - Aufgabe.WertB;
                Ergebnis.Erfolg = true;
            }
        }

        private void Multiplizieren()
        {
            if (Aufgabe.OK)
            {
                Ergebnis.Wert = Aufgabe.WertA * Aufgabe.WertB;
                Ergebnis.Erfolg = true;
            }
        }

        private void Dividieren()
        {
            if (Aufgabe.OK)
            {
                Ergebnis.Wert = Aufgabe.WertA / Aufgabe.WertB;
                Ergebnis.Erfolg = true;
            }
        }

        private void Potenzieren()
        {
            if (Aufgabe.OK)
            {
                if (Aufgabe.WertB < 0)
                {
                    Ergebnis.Erfolg = false;
                    return;
                }
                Ergebnis.Wert = 1;
                for (int i = 0; i < Aufgabe.WertB; i++)
                {
                    Ergebnis.Wert *= Aufgabe.WertA;
                }
                Ergebnis.Erfolg = true;
            }
        }
    }



    class Rechenaufgabe
    {
        public string Aufgabe { get; set; }
        public char Operation { get; set; }
        public int IndexOperation { get; set; }
        public double WertA { get; set; }
        public double WertB { get; set; }
        public bool OK { get; set; }
        private const string MOEGLICHEOPERATIONEN = "+-*/^";

        public Rechenaufgabe()
        {
            Aufgabe = "";
            Operation = ' ';
            IndexOperation = 0;
            WertA = 0.0;
            WertB = 0.0;
            OK = false;
        }

        public void EmpfangeAufgabe(string NeueAufgabe)
        {
            Aufgabe = NeueAufgabe;
            IndexOperation = Aufgabe.IndexOfAny(MOEGLICHEOPERATIONEN.ToCharArray(), 1);
            Operation = Aufgabe[IndexOperation];
            try
            {
                WertA = double.Parse(Aufgabe.Substring(0, IndexOperation));
                WertB = double.Parse(Aufgabe.Substring(IndexOperation + 1));
                OK = true;
            }
            catch (Exception)
            {
                OK = false;
            }
        }
    }



    public class Ergebnis
    {
        public double Wert { get; set; }
        public bool Erfolg { get; set; }

        public Ergebnis()
        {
            Erfolg = false;
            Wert = 0.0;
        }
    }
}
