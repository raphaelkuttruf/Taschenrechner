
/// <summary>
/// Ermöglicht die Berechnung einfacher mathematischer Operationen in der Kommandozeile
/// </summary>
namespace Taschenrechner
{
    /// <summary>
    /// Die auszuführende Rechenoperation wird zur Laufzeit vom <see cref="Programm"/> bestimmt.
    /// </summary>
    /// <seealso cref="https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/delegates/"/>
    delegate void Rechenoperation();


    /// <summary>
    /// Programmeinstieg und Programmablauf
    /// </summary>
    /// @todo Mehr und besseren Code schreiben und dabei neue Sachen lernen :P 
    class Programm
    {
        /// <summary>
        /// Programmeinstiegspunkt
        /// </summary>
        /// <param name="args">Wird nicht verwendet!</param>
        public static void Main(string[] args)
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
}
