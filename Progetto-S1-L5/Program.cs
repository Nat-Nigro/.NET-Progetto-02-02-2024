using System;

namespace Progetto_S1_L5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creiamo l'istanza della classe Contribuente
            Contribuente contribuente = new Contribuente();

            contribuente.Benvenuto();
            Console.WriteLine("\n");
            contribuente.Riepilogo();

            Console.ReadLine(); // Evita la chiusura preventiva della schermata di debug
        }
    }
}
