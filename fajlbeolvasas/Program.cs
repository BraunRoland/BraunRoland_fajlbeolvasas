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
    }
}
