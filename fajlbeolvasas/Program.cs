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
            F07(karakterek);
            F08(karakterek);
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

        static void F07(List<Karakter> karakterek)
        {
            string fajlnev = "karakterek.csv";
            Iras(karakterek, fajlnev);
            Olvasas(karakterek, fajlnev);
        }

        static void Iras( List<Karakter> karakterek,string fajlnev)
        {
            StreamWriter sw = new(fajlnev);
            sw.WriteLine("Név;Szint;Életerő;Erő");
            foreach (var item in karakterek)
            {
                sw.WriteLine($"{item.Name};{item.Szint};{item.Eletero};{item.Ero}");
            };
            sw.Close();
            Console.WriteLine("Írás kész.");
        }

        static void Olvasas(List<Karakter> karakterek, string fajlnev)
        {
            StreamReader sr = new(fajlnev);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                Console.WriteLine(sor);
            }
        }

        static void F08(List<Karakter> karakterek)
        {
            List<Karakter> uj = [];
            List<Karakter> regi = karakterek;
            foreach (var item in regi)
            {
                Console.WriteLine(item.ToString());
            }

            for (int i = 0; i < 3; i++)
            {
                int index = 0;
                int max = 0;
                for (int j = 0; j < regi.Count-1; j++)
                {
                    int keresett = regi[j].Szint + regi[j].Ero;
                    if (keresett > max)
                    {
                        max = keresett;
                        index = j;
                    }
                    Console.WriteLine(regi[j]);
                }
                uj[i] = regi[index];
                Console.WriteLine($"\n\n{uj.ToString()}");
                regi.RemoveAt(index);
            }
            Console.WriteLine("8.Feladat: Top 3 karakter:");
            foreach (var item in uj)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void F09(List<Karakter> karakterek)
        {
            Console.WriteLine("9. feladat: ");
            Karakter csere;
            for (int i = 0; i < karakterek.Count; i++)
            {
                for (int j = i + 1; j < karakterek.Count; j++)
                {
                    int k1 = karakterek[i].Ero + karakterek[i].Szint;
                    int k2 = karakterek[j].Ero + karakterek[j].Szint;
                    if (k1 > k2)
                    {
                        csere = karakterek[j];
                        karakterek[j] = karakterek[i];
                        karakterek[i] = csere;
                    }
                }
            }
            foreach(var item in karakterek)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
