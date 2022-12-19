using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Restaurant.Entities;
using Restaurant.Meniu;
using Restaurant.Repozitorijos;

namespace Restaurant.BusinessLogic
{
    public class Restoranas
    {
        public MaistoRepozitorija maistoRepozitorija { get; set; }
        public GerimuRepozitorija gerimuRepozitorija { get; set; }
        public PadavejoRepozitorija padavejoRepozitorija { get; set; }
        public StaliukoRepozitorija staliukoRepozitorija { get; set; }
        public List<Uzsakymas> Uzsakymai { get; set; }
        public Restoranas()  
        {
            maistoRepozitorija = new MaistoRepozitorija();
            gerimuRepozitorija = new GerimuRepozitorija();
            padavejoRepozitorija = new PadavejoRepozitorija();
            staliukoRepozitorija = new StaliukoRepozitorija();
        }
       
        public void UserInterface()
        {
            Console.WriteLine("***********************************************************************************");
            Console.WriteLine("\n\t\t\t\t SVEIKI ATVYKE\n\t\t\t\t SISTEMA KRAUNASI\n");                             
            Console.WriteLine("***********************************************************************************");
            Console.ReadLine();
            var padaveja = NaujasPadavejas(padavejoRepozitorija);
            List<BendraInformacija> informacija = new List<BendraInformacija>();
            informacija.AddRange(maistoRepozitorija.Maistas);
            informacija.AddRange(gerimuRepozitorija.Gerimai);
            Meniu(padaveja, informacija);
            
        }
        public void Meniu(Padavejas padavejas, List<BendraInformacija> informacija)
        {
            Uzsakymai = new List<Uzsakymas>();
            bool repeat = true;

            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("[1] - Naujas uzsakymas\n\n[2] - Neapmoketi uzsakymai\n\n[3] - Prideti prie uzsakymo\n\n[4] - Uzbaigti uzsakyma\n\n[5] - Isjungti");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        NaujasUzsakymas(informacija);
                        break;
                    case "2":
                        Console.Clear();
                        VykdomiUzsakymai(Uzsakymai);
                        break;
                    case "3":
                        Console.Clear();
                        UzsakymoPildymas(informacija);
                        break;
                    case "4":
                        Console.Clear();
                        UzbaigtiUzsakyma(padavejas);
                        break;
                    case "5":
                        Console.Clear();
                        repeat = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Blogai ivesta");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public static Padavejas NaujasPadavejas(PadavejoRepozitorija padavejoRepozitorija)
        {
            Console.Clear();
            Console.WriteLine("Iveskite padavejo ID");
            padavejoRepozitorija.RodykVisus();
            int padavejosID = Convert.ToInt32(Console.ReadLine());
            var padavejas = padavejoRepozitorija.RetriveByID(padavejosID);
            Console.Clear();
            Console.WriteLine("Prisijunge " + padavejas.PadavejoVardas);
            Console.ReadLine();
            return padavejas;
        }
        public void NaujasUzsakymas(List<BendraInformacija> maistas)
        {
            Console.WriteLine("Issirinkite laisva staliuka");
            staliukoRepozitorija.RodykPasirinkta(true);
            int staliukoID = Convert.ToInt32(Console.ReadLine());
            Uzsakymai.Add(new Uzsakymas { StaliukoID = staliukoID, Informacija = new List<BendraInformacija>(), BendraSuma = 0m });
            staliukoRepozitorija.PakeiskStaliukoStatusa(staliukoID, false);

            Console.Clear();
            Console.WriteLine("Jeigu norite papildyti uzsakyma spauskite 0 ");
            if (Console.ReadLine() == "0")
            {
                PasirinktiMaista(staliukoID, maistas);
            }
            
        }
        public void VykdomiUzsakymai(List<Uzsakymas> uzsakymai)
        {
            Console.WriteLine("Vykdomi uzsakymai:");
            foreach (var item in uzsakymai)
            {
                Console.WriteLine($"Staliuko ID {item.StaliukoID}, saskaitos suma: {item.BendraSuma} $");
               
            }
            Console.ReadLine();
        }
        public void UzsakymoPildymas(List<BendraInformacija> maistas)
        {
            Console.WriteLine("Pasirinkite, kurio staliuko uzsakyma norite pildyti:");
            staliukoRepozitorija.RodykPasirinkta(false);
            int staliukoID = Convert.ToInt32(Console.ReadLine());

            if (Uzsakymai.Any(x => x.StaliukoID == staliukoID))
            {
                PasirinktiMaista(staliukoID, maistas);
            }
            else 
            {
                Console.Clear();
                Console.WriteLine("Staliukas tuscias");
                Console.ReadLine();
            }
        }
        public void PasirinktiMaista(int staliukoID, List<BendraInformacija> maistas)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Maisto meniu - [1]\nGerimu meniu - [2] ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        maistoRepozitorija.RodykVisus();
                        Console.WriteLine("Iveskite patiekalo ID:");
                        int itemID = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Iveskite norima kieki");
                        int kiekis = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < kiekis; i++)
                        {
                            var uzsakymas = Uzsakymai.FirstOrDefault(x => x.StaliukoID == staliukoID);
                            var item = maistas.FirstOrDefault(x => x.ID == itemID);
                            uzsakymas.Informacija.Add(item);
                            uzsakymas.BendraSuma += item.Kaina;
                            
                        }
                        Console.Clear();
                        Console.WriteLine("Jeigu norite papildyti uzsakyma spauskite 0 ");
                        if (Console.ReadLine() != "0")
                        {
                            repeat = false;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        gerimuRepozitorija.RodykVisus();
                        Console.WriteLine("Iveskite gerimo ID:");
                        int gerimoID = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Iveskite norima kieki");
                        int vienetai = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < vienetai; i++)
                        {
                            var uzsakymas = Uzsakymai.FirstOrDefault(x => x.StaliukoID == staliukoID);
                            var item = maistas.FirstOrDefault(x => x.ID == gerimoID);
                            uzsakymas.Informacija.Add(item);
                            uzsakymas.BendraSuma += item.Kaina;
                        }
                        Console.Clear();
                        Console.WriteLine("Jeigu norite papildyti uzsakyma spauskite 0 ");
                        if (Console.ReadLine() != "0")
                        {
                            repeat = false;
                        }
                        break;
                        

                }
            }
        }
        public void UzbaigtiUzsakyma(Padavejas padavejas)
        {
            Console.WriteLine("Pasirinkite, kuriam staliukui norite pateikti saskaita:");
            staliukoRepozitorija.RodykPasirinkta(false);
            int staliukoID = Convert.ToInt32(Console.ReadLine());
            var uzsakymas = Uzsakymai.First(x => x.StaliukoID == staliukoID);
            RuostiCeki(uzsakymas, padavejas);
            Uzsakymai.Remove(Uzsakymai.First(x => x.StaliukoID == staliukoID));
            staliukoRepozitorija.PakeiskStaliukoStatusa(staliukoID, true);
            
        }
        public void RuostiCeki(Uzsakymas uzsakymas, Padavejas padavejas)
        {
            Console.Clear();
            string restoranui = CekisRestoranui(uzsakymas, padavejas);
            string klientui = CekisKlientui(uzsakymas, padavejas);

            var FilePath = (@"C:\C#egzaminas\Restaurant\Restaurant\ListCSV\Ataskaita.csv");
            using (StreamWriter writer = new StreamWriter(new FileStream(FilePath,
            FileMode.Create, FileAccess.Write)))
            {
                writer.WriteLine(restoranui);
                Console.WriteLine("Jeigu norite spausdinti ceki klientui spauskite 0");
                if (Console.ReadLine() == "0")
                {
                    writer.WriteLine($"\n\n\n{klientui}");
                }
            }
           

        }
        public string CekisRestoranui(Uzsakymas uzsakymas, Padavejas padavejas)
        {
            string cekioInformacija = $"Data:{DateTime.Now}\nPadavejo ID:{padavejas.PadavejoID}\n" +
                    $"Staliuko numeris:{uzsakymas.StaliukoID}\nID:";
            foreach (var item in uzsakymas.Informacija)
            {
                cekioInformacija += $"{item.ID}";
            }
            cekioInformacija += $"\nGalutine suma:{uzsakymas.BendraSuma}";
            return cekioInformacija;
        }
        public string CekisKlientui(Uzsakymas uzsakymas, Padavejas padavejas)
        {
            string cekioInformacija = $"Data:{DateTime.Now}\nJus aptarnavo padavejas {padavejas.PadavejoVardas}\n" +
                    $"Staliuko numeris:{uzsakymas.StaliukoID}\nID:  Patiekalas:  Kaina:\n";
            foreach (var item in uzsakymas.Informacija)
            {
                cekioInformacija += $"{item.ID}  {item.Pavadinimas},  {item.Kaina}";
            }
            cekioInformacija += $"\nGalutine suma:{uzsakymas.BendraSuma}";
            return cekioInformacija;
        }

    }
}
