public class BankKonto
{
    public string Kontoinnehavare { get; set; }
    public int Kontonummer { get; set; }
    public double Saldo { get; set; }

    // Konstruktor
    public BankKonto(string kontoinnehavare, int kontonummer, double saldo)
    {
        Kontoinnehavare = kontoinnehavare;
        Kontonummer = kontonummer;
        Saldo = saldo;
    }

    // Metod för att sätta in pengar
    public void SättInPengar(double belopp)
    {
        Saldo += belopp;
        Console.WriteLine($"{belopp} kr insatt på konto {Kontonummer}. Nytt saldo: {Saldo} kr.");
    }

    // Metod för att ta ut pengar
    public void TaUtPengar(double belopp)
    {
        if (belopp <= Saldo)  // Kontrollera om beloppet är mindre än eller lika med saldot
        {
            Saldo -= belopp;
            Console.WriteLine($"{belopp} kr uttaget från konto {Kontonummer}. Nytt saldo: {Saldo} kr.");
        }
        else
        {
            Console.WriteLine("Otillräckligt saldo.");
        }
    }

    // Metod för att överföra pengar mellan två konton
    public void ÖverföraPengarMellanKonto(BankKonto tillKonto, double belopp)
    {
        if (belopp <= 0)
        {
            Console.WriteLine("Beloppet måste vara större än 0.");
            return;
        }

        if (Saldo >= belopp)
        {
            Saldo -= belopp;            // Minskar saldot på kontot vi överför från
            tillKonto.Saldo += belopp;   // Ökar saldot på mottagarkontot
            Console.WriteLine($"Överförde {belopp} kr från konto {Kontonummer} till konto {tillKonto.Kontonummer}. Nytt saldo: {Saldo} kr.");
        }
        else
        {
            Console.WriteLine("Otillräckligt saldo för att genomföra överföringen.");
        }
    }
}
