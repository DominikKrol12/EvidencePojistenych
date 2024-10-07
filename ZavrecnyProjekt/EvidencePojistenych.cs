using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavrecnyProjekt
{
    // Třída pro evidenci pojištěných
    public class EvidencePojistenych
    {
        private List<Pojisteny> listPojisteni = new List<Pojisteny>();

        public void PridatPojisteneho()
        {
            string jmeno;
            string prijmeni;
            int vek;
            string telefon;

            // Validace jména
            do
            {
                Console.WriteLine("Zadejte jméno pojištěného:");

                jmeno = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(jmeno))
                    Console.WriteLine("Jméno nesmí být prázdné.");

                if (jmeno.ToString().Length > 20)
                    Console.WriteLine("Jméno nesmí být delsi jak 20 znaku.");

            } while (string.IsNullOrWhiteSpace(jmeno));

            // Validace příjmení
            do
            {
                Console.WriteLine("Zadejte příjmení:");
                prijmeni = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(prijmeni))
                    Console.WriteLine("Příjmení nesmí být prázdné.");

            } while (string.IsNullOrWhiteSpace(prijmeni));

            // Validace věku
            do
            {
                Console.WriteLine("Zadejte věk:");
                if (!int.TryParse(Console.ReadLine(), out vek) || vek <= 0 || vek > 120)
                    Console.WriteLine("Zadejte platný věk (1-120).");

            } while (vek <= 0 || vek > 120);

            // Validace telefonního čísla
            do
            {
                Console.WriteLine("Zadejte telefonní číslo:");
                telefon = Console.ReadLine();
                // Ověření, že číslo je neprázdné, obsahuje jen číslice a má správnou délku
                if (string.IsNullOrWhiteSpace(telefon) || telefon.Length < 9 || telefon.Length > 13 || !telefon.All(char.IsDigit))
                {
                    Console.WriteLine("Zadejte platné telefonní číslo (9-12 číslic).");
                }
                else
                {
                    // Naformátování čísla po skupinách po 3 číslicích
                    telefon = string.Join(" ", Enumerable.Range(0, telefon.Length / 3)
                                            .Select(i => telefon.Substring(i * 3, Math.Min(3, telefon.Length - i * 3))));
                    break;
                }

            } while (true);

            // Vytvoření nové instance pojištěného a jeho přidání do evidence
            Pojisteny pojisteny = new Pojisteny(jmeno, prijmeni, vek, telefon);
            listPojisteni.Add(pojisteny);

            Console.WriteLine("");
            Console.WriteLine("Data byla uložena.");
        }

        // Metoda pro výpis všech pojištěných osob
        public void VypisVsechny()
        {
            Console.WriteLine("Seznam pojištěných:");
            Console.WriteLine("");
            foreach (var pojisteny in listPojisteni) 
            {
                Console.WriteLine(pojisteny);
            }
        }

        public void VyhledatPojisteneho()
        {
            string jmeno;
            string prijmeni;

            // Validace jména
            do
            {
                Console.WriteLine("Zadejte jméno pojištěného:");
                jmeno = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(jmeno))
                    Console.WriteLine("Jméno nesmí být prázdné.");
            } while (string.IsNullOrWhiteSpace(jmeno));

            // Validace příjmení
            do
            {
                Console.WriteLine("Zadejte příjmení:");
                prijmeni = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(prijmeni))
                    Console.WriteLine("Příjmení nesmí být prázdné.");
            } while (string.IsNullOrWhiteSpace(prijmeni));

            // Vyhledání pojištěného v evidenci
            foreach (var pojisteny in listPojisteni)
            {
                if (pojisteny.Jmeno.Contains(jmeno, StringComparison.OrdinalIgnoreCase) &&
                    pojisteny.Prijmeni.Contains(prijmeni, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(pojisteny);
                    return;
                }
            }

            Console.WriteLine("Pojištěný nenalezen.");
        }
    }
}