namespace Bankapplikation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Starta bankapplikationen
            BankSystem bankSystem = new BankSystem();
            bankSystem.Starta();
        }
    }
}
