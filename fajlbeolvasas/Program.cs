namespace fajlbeolvasas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Karakter> karakterek = [];
            Beolvasas("karakterek.txt", karakterek);
            foreach (var item in karakterek)
            {
                Console.WriteLine(item.ToString());
            }
            F03(karakterek);
            F04(karakterek);
            F05(karakterek);
            F06(karakterek);
        }

        static void Beolvasas(string fajlnev, List<Karakter> karakterek)
        {
            StreamReader sr = new(fajlnev);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] szavak = sor.Split(";");
                Karakter karakter = new(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
                karakterek.Add(karakter);
            }
        }

        static void F03(List<Karakter> karakterek)
        {
            int atlag = 0;
            foreach (var item in karakterek)
            {
                atlag += item.Szint;
            };
            Console.WriteLine("3. feladat: szint átlaga");
            Console.WriteLine($"- {atlag/karakterek.Count}");
        }

        static void F04(List<Karakter> karakterek)
        {
            Console.WriteLine("4. feladat: ");
            Karakter csere;
            for (int i = 0; i < karakterek.Count; i++)
            {
                for (int j = i + 1; j < karakterek.Count; j++)
                {
                    if (karakterek[i].Ero > karakterek[j].Ero)
                    {
                        csere = karakterek[j];
                        karakterek[j] = karakterek[i];
                        karakterek[i] = csere;
                    }
                }
            }
            foreach (var item in karakterek)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void F05(List<Karakter> karakterek)
        {
            Console.Write("5. Feladat:\nAdj meg egy Számot: ");
            int szam = Convert.ToInt32(Console.ReadLine());
            foreach (var item in karakterek)
            {
                Console.WriteLine($"{item.Name} - {item.ErossebE(szam)}");
            }
        }

        static void F06(List<Karakter> karakterek)
        {
            Console.Write("6. Feladat:\nAdj meg egy Számot: ");
            int szam = Convert.ToInt32(Console.ReadLine());
            foreach (var item in karakterek)
            {
                if (item.KarakterStats(szam) == true)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
