using System;

namespace Progetto_S1_L5
{
    internal class Contribuente
    {
        /* Definiamo tutte le proprietà della classe Contribuente */

        private string _nome;
        private string _cognome;
        private DateTime _dataDiNascita;
        private string _codiceFiscale;
        private char _sesso;
        private string _comuneDiResidenza;
        private int _redditoAnnuale;

        public string Nome { get { return _nome; } set { _nome = value; } }
        public string Cognome { get { return _cognome; } set { _cognome = value; } }
        public DateTime DataDiNascita { get { return _dataDiNascita; } set { _dataDiNascita = value; } }
        public string CodiceFiscale { get { return _codiceFiscale; } set { _codiceFiscale = value; } }
        public char Sesso { get { return _sesso; } set { _sesso = value; } }
        public string ComuneDiResidenza { get { return _comuneDiResidenza; } set { _comuneDiResidenza = value; } }
        public int RedditoAnnuale { get { return _redditoAnnuale; } set { _redditoAnnuale = value; } }


        public void Benvenuto() // Primo metodo, inseriamo e stampiamo i dati richiesti
        {
            // Passiamo alla creazione del portale, (in gran parte da output)
            Console.WriteLine("INSERISCI I TUOI DATI");

            Console.WriteLine("Nome: ");
            Nome = Console.ReadLine();

            Console.WriteLine("Cognome: ");
            Cognome = Console.ReadLine();

            Console.WriteLine("Data di nascita gg/mm/aaaa");
            DataDiNascita = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Codice Fiscale: ");
            CodiceFiscale = Console.ReadLine();
            //Per garantire l'esatta lunghezza del codice fiscale, utiliziamo un ciclo while, che si ripete finchè la lunghezza non sarà uguale a 16
            while (CodiceFiscale.Length != 16)
            {
                Console.WriteLine("Codice inserito non valido, riprovare.");
                CodiceFiscale = Console.ReadLine();
            }

            Console.WriteLine("Sesso (M/F): ");
            Sesso = char.Parse(Console.ReadLine());



            Console.WriteLine("Comune di residenza: ");
            ComuneDiResidenza = Console.ReadLine();

            /* In questo caso il ciclo while continuerà fin quando lo stato di inputValido non diventa true.
             Con int.TryParse convertiamo l'input dell'utente e lo stato passerà a true, uscendo quindi dal ciclo
             */
            bool inputValido = false;
            int redditoValido;

            Console.WriteLine("Dichiarare il reddito: ");

            while (!inputValido)
            {
                string input = Console.ReadLine();

                inputValido = int.TryParse(input, out redditoValido);

                if (inputValido)
                {
                    RedditoAnnuale = redditoValido;
                }
                else
                {
                    Console.WriteLine("Carattere inserito non valido, riprovare:");
                }
            }

        }

        // Passiamo al metodo per calcolare l'aliquota da pagare

        public double Aliquota()
        {
            if (RedditoAnnuale <= 15000)
            {
                return RedditoAnnuale * 0.23;
            }
            else if (RedditoAnnuale <= 28000)
            {
                return 3450 + (RedditoAnnuale - 15000) * 0.27;
            }
            else if (RedditoAnnuale <= 55000)
            {
                return 6960 + (RedditoAnnuale - 28000) * 0.38;
            }
            else if (RedditoAnnuale <= 75000)
            {
                return 17220 + (RedditoAnnuale - 55000) * 0.41;
            }
            else // Per i redditi superiori a quelli precedentemente indicati
            {
                return 25420 + (RedditoAnnuale - 75000) * 0.43;
            }
        }

        public void Riepilogo()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine($"CALCOLO DELL'IMPOSTA DA VERSARE:");
            Console.WriteLine($"Contribuente: {Nome} {Cognome},");
            Console.WriteLine($"Nato il {DataDiNascita.ToString("dd/MM/yyyy")} ({Sesso}),");
            Console.WriteLine($"Residente in {ComuneDiResidenza},");
            Console.WriteLine($"Codice fiscale: {CodiceFiscale}");
            Console.WriteLine($"Reddito dichiarato: {RedditoAnnuale.ToString("N2")}");
            Console.WriteLine($"IMPOSTA DA VERSARE: \u20AC  {Aliquota().ToString("N2")}");
        }
        /* Con N2 e ToString formattiamo il numero, quindi separazione (migliaia etc.)
         2 indica le cifre da visualizzare dopo il separatore decimale 
        \u220AC restituisce il simbolo dell'uero
         */

    }
}
