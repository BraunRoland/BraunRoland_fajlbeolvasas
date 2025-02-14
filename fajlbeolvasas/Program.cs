namespace fajlbeolvasas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Karakter> karakterek = [];
            Beolvasas("karakterek.txt", karakterek);
            //foreach (var item in karakterek)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            F03(karakterek);
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
    }
}
