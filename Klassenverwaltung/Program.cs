using System;

namespace Klassenverwaltung
{
    class Program
    {
        public static void Acknowledge()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.Write("Bitte beliebige Taste zum Fortfahren drücken . . .");
            Console.ReadKey();
            Console.Clear();
        }

        public static void AddNewPupilToPupilsArray(ref Pupil[] pupils, ref int pupilsIndex)
        {
            pupils[pupilsIndex] = CreateNewPupil();
            Acknowledge();
        }

        public static Pupil CreateNewPupil()
        {
            Pupil pupil = new Pupil();
            Console.Write("Bitte Katalog-Nr. eingeben: ");
            pupil.SetCatalogNr(Convert.ToInt32(Console.ReadLine()));
            Console.Write("Bitte Vornamen eingeben: ");
            pupil.SetFirstName(Console.ReadLine());
            Console.Write("Bitte Nachnamen eingeben: ");
            pupil.SetLastName(Console.ReadLine());
            Console.Write("Bitte Postleitzahl des Wohnortes eingeben: ");
            pupil.SetZipCode(Convert.ToInt32(Console.ReadLine()));
            return pupil;
        }

        public static void PrintOutPupilsArray(ref Pupil[] pupils)
        {
            Console.Clear();
            Console.WriteLine("{0,10} | {1,-20} | {2,-20} | {3,5}","Katalog-Nr","Vorname","Nachname","Plz");
            for (int i = 0; i < pupils.Length; i++)
            {
                if(pupils[i] != null)
                {
                    Console.WriteLine("{0,10} | {1,-20} | {2,-20} | {3,5}", pupils[i].GetCatalogNr(), pupils[i].GetFirstName(), pupils[i].GetLastName(), pupils[i].GetZipCode());
                }      
            }

            Acknowledge();
        }
        
        public static void PrintOutPupilIfZipcodeMatches(ref Pupil[] pupils)
        {
            
            int zipCode;
            Console.Write("Welche Postleitzahl?: ");
            zipCode = Convert.ToInt32(Console.ReadLine());
            
            Console.Clear();
            Console.WriteLine("{0,10} | {1,-20} | {2,-20} | {3,5}", "Katalog-Nr", "Vorname", "Nachname", "Plz");
            for (int i = 0; i < pupils.Length; i++)
            {
                if(pupils[i] != null)
                {
                    if (zipCode == pupils[i].GetZipCode())
                    {
                        Console.WriteLine("{0,10} | {1,-20} | {2,-20} | {3,5}", pupils[i].GetCatalogNr(), pupils[i].GetFirstName(), pupils[i].GetLastName(), pupils[i].GetZipCode());
                    }
                }
            }

            Acknowledge();
        }

        static void Main(string[] args)
        {
            int menuNr;
            int pupilsIndex = 0;
            Pupil[] pupils = new Pupil[40];


            do
            {
                Console.WriteLine("MENÜ:");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("1: Neuen Schüler anlegen");
                Console.WriteLine("2: Liste nach Katalognummer sortieren");
                Console.WriteLine("3: Liste nach Nachnamen sortieren");
                Console.WriteLine("4: Ausgabe der Liste");
                Console.WriteLine("5: Schüler je Postleitzahl ausgeben");
                Console.WriteLine("0: ENDE");
                Console.Write("Menüpunkt auswählen: ");
                menuNr = Convert.ToInt32(Console.ReadLine());
                switch (menuNr)
                {
                    case 1:
                        if (pupilsIndex < (pupils.Length - 1))
                        {
                            AddNewPupilToPupilsArray(ref pupils, ref pupilsIndex);
                            pupilsIndex++;
                        }
                        else
                        {
                            Console.WriteLine("Die Klasse hat das Maximum von 40 Schülern erreicht!");
                        }
                        break;
                    case 2:
                        //TODO
                        break;
                    case 3:
                        //TODO
                        break;
                    case 4:
                        PrintOutPupilsArray(ref pupils);
                        break;
                    case 5:
                        PrintOutPupilIfZipcodeMatches(ref pupils);
                        break;
                    case 0:
                        //DO NOTHING
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe! Bitte nur Zahlen zwischen 0 und 5 eingeben.");
                        Console.Write("Bitte beliebige Taste zum Fortfahren drücken . . .");
                        Console.ReadKey();
                        break;
                }
            } while (menuNr != 0);
            
        }
    }
}
