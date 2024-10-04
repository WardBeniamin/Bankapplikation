namespace Bankapplikation
{
    public class BankSystem
    {
        private BankKonto personkonto;
        private BankKonto sparkonto;
        private BankKonto investeringskonto;

        public BankSystem()
        {
            // Skapa tre konton för samma person, Mario
            personkonto = new BankKonto("Mario", 123456, 10000);
            sparkonto = new BankKonto("Mario", 654321, 5000);
            investeringskonto = new BankKonto("Mario", 789012, 20000);
        }

        public void Starta()
        {
            bool körProgram = true;
            while (körProgram)
            {
                Console.WriteLine("\nVälj ett alternativ:");
                Console.WriteLine("1. Visa saldo");
                Console.WriteLine("2. Sätt in pengar");
                Console.WriteLine("3. Ta ut pengar");
                Console.WriteLine("4. Överför pengar mellan konton");
                Console.WriteLine("5. Avsluta");

                string val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        VisaSaldo();
                        break;
                    case "2":
                        HanteraInsättning();
                        break;
                    case "3":
                        HanteraUttag();
                        break;
                    case "4":
                        HanteraÖverföring();
                        break;
                    case "5":
                        körProgram = false;
                        Console.WriteLine("Tack för att du använde vår banktjänst!");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }

        private void VisaSaldo()
        {
            Console.WriteLine($"Personkonto saldo: {personkonto.Saldo} kr");
            Console.WriteLine($"Sparkonto saldo: {sparkonto.Saldo} kr");
            Console.WriteLine($"Investeringskonto saldo: {investeringskonto.Saldo} kr");
        }

        private void HanteraInsättning()
        {
            Console.WriteLine("Välj konto att sätta in pengar på (1: Personkonto, 2: Sparkonto, 3: Investeringskonto)");
            string kontoVal = Console.ReadLine();
            Console.WriteLine("Hur mycket vill du sätta in?");
            double belopp = Convert.ToDouble(Console.ReadLine());

            if (kontoVal == "1")
            {
                personkonto.SättInPengar(belopp);
            }
            else if (kontoVal == "2")
            {
                sparkonto.SättInPengar(belopp);
            }
            else if (kontoVal == "3")
            {
                investeringskonto.SättInPengar(belopp);
            }
        }

        private void HanteraUttag()
        {
            Console.WriteLine("Välj konto att ta ut pengar från (1: Personkonto, 2: Sparkonto, 3: Investeringskonto)");
            string kontoVal = Console.ReadLine();
            Console.WriteLine("Hur mycket vill du ta ut?");
            double belopp = Convert.ToDouble(Console.ReadLine());

            if (kontoVal == "1")
            {
                personkonto.TaUtPengar(belopp);
            }
            else if (kontoVal == "2")
            {
                sparkonto.TaUtPengar(belopp);
            }
            else if (kontoVal == "3")
            {
                investeringskonto.TaUtPengar(belopp);
            }
        }

        private void HanteraÖverföring()
        {
            Console.WriteLine("Välj konto att överföra från (1: Personkonto, 2: Sparkonto, 3: Investeringskonto)");
            string frånKontoVal = Console.ReadLine();
            Console.WriteLine("Välj konto att överföra till (1: Personkonto, 2: Sparkonto, 3: Investeringskonto)");
            string tillKontoVal = Console.ReadLine();
            Console.WriteLine("Hur mycket vill du överföra?");
            double belopp = Convert.ToDouble(Console.ReadLine());

            BankKonto frånKonto = null;
            BankKonto tillKonto = null;

            if (frånKontoVal == "1") frånKonto = personkonto;
            else if (frånKontoVal == "2") frånKonto = sparkonto;
            else if (frånKontoVal == "3") frånKonto = investeringskonto;

            if (tillKontoVal == "1") tillKonto = personkonto;
            else if (tillKontoVal == "2") tillKonto = sparkonto;
            else if (tillKontoVal == "3") tillKonto = investeringskonto;

            if (frånKonto != null && tillKonto != null)
            {
                frånKonto.ÖverföraPengarMellanKonto(tillKonto, belopp);
            }
        }
    }
}
