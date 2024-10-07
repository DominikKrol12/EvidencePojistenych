using System;
using ZavrecnyProjekt;

class Program
{
    static void Main(string[] args)
    {
        EvidencePojistenych evidence = new EvidencePojistenych();
        bool pokracovat = true;

        // Hlavní cyklus programu, který běží, dokud uživatel nezvolí možnost "konec"
        while (pokracovat)
        {
            int volba;

            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Evidence pojištěných");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
            Console.WriteLine("1 - Přidat nového pojištěného");
            Console.WriteLine("2 - Vypsat všechny pojištěné");
            Console.WriteLine("3 - Vyhledat pojištěného");
            Console.WriteLine("4 - Konec");
            Console.WriteLine("Vyberte si akci:");

            while (!int.TryParse(Console.ReadLine(), out volba) || volba < 1 || volba > 4)
                Console.WriteLine("Neplatný vstup. Zadejte prosím číslo mezi 1 a 4:");
            switch (volba)
            {
                case 1:
                    evidence.PridatPojisteneho();
                    break;
                case 2:
                    evidence.VypisVsechny();
                    break;
                case 3:
                    evidence.VyhledatPojisteneho();
                    break;
                case 4:
                    pokracovat = false;
                    break;
                default:
                    Console.WriteLine("Neplatná volba, zkuste to znovu.");
                    break;
            }

            Console.WriteLine("");
            Console.WriteLine("Pokračujte libovolnou klávesou...");
            Console.ReadKey();
        }
    }
}