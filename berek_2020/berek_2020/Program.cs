namespace berek_2020
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string elsosor;
            List<Berek> lista = new List<Berek>();

            FileStream fs = new FileStream("berek2020.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            elsosor = sr.ReadLine()!;
            while (!sr.EndOfStream)
            {
                lista.Add(new Berek(sr.ReadLine()!));
            }

            Console.WriteLine($"3. Feladat: Dolgozók száma: {lista.Count} fő");

            double osszeg = lista.Sum(k => k.Ber);
            double atlag = (osszeg / lista.Count) / 1000;
            Console.WriteLine($"4. Feladat: Bérek átlaga: {Math.Round(atlag, 1)} eFt");

            Console.Write("5. Feladat: Kérem a részleg nevét: ");
            string input = Console.ReadLine()!;

            List<Berek> inputreszleg = lista.FindAll(b => b.Hely == input);

            if(inputreszleg.Count > 0)
            {
                int max = inputreszleg.Max(k => k.Ber);
                Berek maxberes = inputreszleg.Find(k => k.Ber == max)!;
                Console.WriteLine($"6. Feladat: A legtöbbet kereső dolgozó a megadott részlegen:");
                Console.WriteLine($"\tNév: {maxberes.Nev}");
                Console.WriteLine($"\tNem : {(maxberes.Neme ? "férfi" : "nő")}");
                Console.WriteLine($"\tBelépés: {maxberes.Csatlakozas}");
                Console.WriteLine($"\tBér: {maxberes.Ber} Forint");
            }
            else
            {
                Console.WriteLine("6. Feladat: A megadott részleg nem létezik a cégnél!");
            }

            Console.WriteLine("7. Feladat: Statisztika");

            var reszlegek = lista.Select(b => b.Hely);
            foreach(var item in reszlegek.Distinct())
            {
                int reszlegdb = lista.Count(b => b.Hely == item);
                Console.WriteLine($"\t{item} - {reszlegdb} fő");
            }

            Console.ReadKey(true);
        }
    }
}
