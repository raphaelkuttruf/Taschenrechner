using System;

namespace Taschenrechner
{
    /// <summary>
    /// Eine Rechenaufgabe die der Taschenrechner ausführen soll.
    /// </summary>
    class Rechenaufgabe
    {
        /// <summary>
        /// Eine Rechenaufgabe mit zwei Zahlenwerten und einem Rechenzeichen
        /// </summary>
        public string Aufgabe { get; set; }
        /// <summary>
        ///  Das in der Aufgabe gefundene Rechenzeichen aus der Lister der möglichen Rechenoperationen
        /// </summary>
        public char Operation { get; set; }
        /// <summary>
        /// Index der Operation in der Aufgabe
        /// </summary>
        public int IndexOperation { get; set; }
        /// <summary>
        /// Der Zahlenwert vor der Operation z.B. Zähler bei der Division
        /// </summary>
        public double WertA { get; set; }
        /// <summary>
        /// Der Zahlenwert nach der Operation z.B. Nenner bei der Division
        /// </summary>
        public double WertB { get; set; }
        /// <summary>
        /// Die Rechenaufgabe wird als in Ordnung und ausführbar bewertet
        /// </summary>
        public bool OK { get; set; }
        /// <summary>
        /// Sammlung der zulässigen Rechenoperationen
        /// </summary>
        private const string MOEGLICHEOPERATIONEN = "+-*/%^";

        /// <summary>
        /// Default Konstruktor.
        /// Das Objekt wird erst nach dem Aufruf von EmpfangeAufgabe() nutzbar.
        /// </summary>
        public Rechenaufgabe()
        {
            Aufgabe = "";
            Operation = ' ';
            IndexOperation = 0;
            WertA = 0.0;
            WertB = 0.0;
            OK = false;
        }

        /// <summary>
        /// Das Objekt nimmt eine neue Zeichenkette als <see cref="Aufgabe"></see> entgegen.
        /// Sie kann z.B. von einer Benutzereingabe kommen.
        /// Es folgt die Verarbeitung und Prüfung der empfangenen Daten.
        /// Punkte Werden durch Kommata ersetzt. 
        /// Leerzeichen werden entfernt.
        /// </summary>
        /// <param name="NeueAufgabe">Eine Rechenaufgabe z.B. "3/4" oder "3.14^2,8"</param>
        /// <exception cref = "RechenaufgabeException" ></exception>
        public void EmpfangeAufgabe(string NeueAufgabe)
        {
            try
            {
                // Punkte durch Kommata ersetzen und Leerzeichen entfernen
                Aufgabe = NeueAufgabe.Trim().Replace('.', ',');
            }
            catch (ArgumentOutOfRangeException aore)
            {
                OK = false;
                throw new RechenaufgabeException(NeueAufgabe, aore);
            }
            try
            {
                // Bestimme Index des Rechenzeichens
                IndexOperation = Aufgabe.IndexOfAny(MOEGLICHEOPERATIONEN.ToCharArray(), 0);
            }
            catch (ArgumentNullException ane)
            {
                OK = false;
                throw new RechenaufgabeException(Aufgabe,ane);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                OK = false;
                throw new RechenaufgabeException(Aufgabe, aore);
            }
            // Speichern des Rechenzeichens der Aufgabe
            Operation = Aufgabe[IndexOperation];
            try
            {
                // Konvertiere Zeichenketten in Gleitkommazahlen
                WertA = double.Parse(Aufgabe.Substring(0, IndexOperation));
                WertB = double.Parse(Aufgabe.Substring(IndexOperation + 1));
                OK = true;
            }
            catch (ArgumentOutOfRangeException aore)
            {
                OK = false;
                throw new RechenaufgabeException(Aufgabe, aore);
            }
            catch (ArgumentNullException ane)
            {
                OK = false;
                throw new RechenaufgabeException(Aufgabe, ane);
            }
            catch (FormatException fe)
            {
                OK = false;
                throw new RechenaufgabeException(Aufgabe, fe);
            }
            catch (OverflowException oe)
            {
                OK = false;
                throw new RechenaufgabeException(Aufgabe, oe);
            }
        }
    }
}
