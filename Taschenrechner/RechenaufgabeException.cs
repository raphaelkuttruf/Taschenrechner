using System;

namespace Taschenrechner
{
    /// <summary>
    /// Fehler beim Konvertieren von Zeichenketten.
    /// Es erfolgt eine Fehlermeldungsausgabe in der Kommandozeile.
    /// </summary>
    /// @see https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
    class RechenaufgabeException : Exception
    {
        const string ErrorMessage = "Fehler bei der Zeichenkettenkonvertierung. ";
        /// <summary>
        /// Default Konstruktor
        /// </summary>
        public RechenaufgabeException()
        {
            Console.WriteLine(ErrorMessage);
        }

        /// <summary>
        /// Spezifische Fehlermeldung
        /// </summary>
        /// <param name="message">Der Fehlermeldetext kann z.B. die originale Zeichenkette der Aufgabe sein</param>
        public RechenaufgabeException(string message)
            : base(ErrorMessage + message)
        {
            Console.WriteLine(ErrorMessage + message);
        }

        /// <summary>
        /// Spezifische Fehlermeldung mit untergeordneter Exception
        /// </summary>
        /// <param name="message">Der Fehlermeldetext kann z.B. die originale Zeichenkette der Aufgabe sein</param>
        /// <param name="inner">Untergeordnete Exception</param>
        public RechenaufgabeException(string message, Exception inner)
            : base(ErrorMessage + message, inner)
        {
            Console.WriteLine(ErrorMessage + message);
            Console.WriteLine(inner.Message);
        }
    }
}
