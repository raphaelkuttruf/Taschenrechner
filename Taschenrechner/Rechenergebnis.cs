
namespace Taschenrechner
{
    /// <summary>
    /// Das Rechenergebnis einer vom Taschenrechner ausgeführten Rechenaufgabe bzw. Rechenoperation
    /// </summary>
    public class Rechenergebnis
    {
        /// <summary>
        /// Der Ergebniswert einer berechneten Rechenaufgabe
        /// </summary>
        public double Wert { get; set; }
        /// <summary>
        /// Rückmeldung ob der Wert durch die erfolgreiche Berechnung einer Rechenaufgabe entstanden ist
        /// </summary>
        public bool Erfolg { get; set; }

        /// <summary>
        /// Default Konstruktor
        /// </summary>
        public Rechenergebnis()
        {
            Erfolg = false;
            Wert = 0.0;
        }
    }
}
