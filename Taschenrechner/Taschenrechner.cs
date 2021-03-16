using System;

namespace Taschenrechner
{
    /// <summary>
    /// 
    /// </summary>
    class Taschenrechner
    {
        /// <summary>
        /// 
        /// </summary>
        public Rechenergebnis Ergebnis { get; }
        /// <summary>
        /// 
        /// </summary>
        public Rechenaufgabe Aufgabe { get; }
        /// <summary>
        /// 
        /// </summary>
        private Rechenoperation Operation;

        /// <summary>
        /// Default Konstruktor
        /// </summary>
        public Taschenrechner()
        {
            Ergebnis = new Rechenergebnis();
            Aufgabe = new Rechenaufgabe();
            Operation = null;
        }

        /// <summary>
        /// Warte auf Benutzerinteraktion durch Texteingabe.
        /// Eine Zeile Text wird eingelesen und als Rechenaufgabe entgegengenommen.
        /// </summary>
        public void EingabeRechenaufgabe()
        {
            try
            {
                Aufgabe.EmpfangeAufgabe(Console.ReadLine());
            }
            catch (RechenaufgabeException)
            {
            }
        }

        /// <summary>
        /// Anhand des in der Rechenaufgabe enthaltenen Rechenzeichens (Rechenaufgabe.Operation)
        /// wird die auszuführende Rechenoperation bestimmt und ausgeführt.
        /// </summary>
        public void BerechneRechenaufgabe()
        {
            switch (Aufgabe.Operation)
            {
                case '+': Operation = Addieren; break;
                case '-': Operation = Subtrahieren; break;
                case '*': Operation = Multiplizieren; break;
                case '/': Operation = Dividieren; break;
                case '%': Operation = Modulo; break;
                case '^': Operation = Potenzieren; break;
                default: Operation = null; break;
            }
            if (Operation != null && Aufgabe.OK)
            {
                Operation();
            }
        }

        /// <summary>
        /// Das Rechenergebnis wird auf der Konsole ausgegeben.
        /// Wenn die eingegebene Aufgabe fehlerhaft oder die Berechnung nich erfolgreich war, wird der Fehler Angezeigt.
        /// </summary>
        public void AusgabeRechenergenis()
        {
            if (!Aufgabe.OK)
            {
                //Console.WriteLine("Fehleingabe");
                return;
            }
            if (!Ergebnis.Erfolg)
            {
                Console.WriteLine("Fehler in der Berechnung");
                return;
            }
            Console.WriteLine(Aufgabe.Aufgabe + " = " + Ergebnis.Wert);
        }

        /// <summary>
        /// Berechnung einer Addition
        /// </summary>
        private void Addieren()
        {
            if (Aufgabe.OK)
            {
                Ergebnis.Wert = Aufgabe.WertA + Aufgabe.WertB;
                Ergebnis.Erfolg = true;
            }
        }

        /// <summary>
        /// Berechnung einer Subtraktion 
        /// </summary>
        private void Subtrahieren()
        {
            if (Aufgabe.OK)
            {
                Ergebnis.Wert = Aufgabe.WertA - Aufgabe.WertB;
                Ergebnis.Erfolg = true;
            }
        }

        /// <summary>
        /// Berechnung einer Multiplikation
        /// </summary>
        private void Multiplizieren()
        {
            if (Aufgabe.OK)
            {
                Ergebnis.Wert = Aufgabe.WertA * Aufgabe.WertB;
                Ergebnis.Erfolg = true;
            }
        }

        /// <summary>
        /// Berechnung einer Division mit der Überprüfung auf Division durch 0.
        /// </summary>
        private void Dividieren()
        {
            if (Aufgabe.OK)
            {
                Ergebnis.Wert = Aufgabe.WertA / Aufgabe.WertB;
                if (Aufgabe.WertB == 0.0)
                {
                    Ergebnis.Erfolg = false;
                    return;
                }
                Ergebnis.Erfolg = true;
            }
        }

        /// <summary>
        /// Berechnung des Rests einer Division.
        /// </summary>
        private void Modulo()
        {
            if (Aufgabe.OK)
            {
                Ergebnis.Wert = Aufgabe.WertA % Aufgabe.WertB;
                Ergebnis.Erfolg = true;
            }
        }

        /// <summary>
        /// Berechnung der n-ten Potenz eines Zahlenwerts.
        /// </summary>
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
}
