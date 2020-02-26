using System;

namespace Klassenverwaltung
{
    class Program
    {
        private static void Acknowledge()
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

        private static Pupil CreateNewPupil()
        {
            Console.WriteLine("---------------------------------------------------");
            Pupil pupil = new Pupil();
            Console.Write("Bitte Katalog-Nr. eingeben:{0,16}"," ");
            pupil.SetCatalogNr(Convert.ToInt32(Console.ReadLine()));
            Console.Write("Bitte Vornamen eingeben:{0,19}", " ");
            pupil.SetFirstName(Console.ReadLine());
            Console.Write("Bitte Nachnamen eingeben:{0,18}", " ");
            pupil.SetLastName(Console.ReadLine());
            Console.Write("Bitte Postleitzahl des Wohnortes eingeben:{0,1}", " ");
            pupil.SetZipCode(Convert.ToInt32(Console.ReadLine()));
            return pupil;
        }

        public static void BubbleSortPupilsArrayByCatalogNr(ref Pupil[] pupils)
        {
            bool aNumberHasSwapped;
            int temp;
            int length=0;

            while (pupils[length] != null)
            {
                length++;
            }
            
            do
            {
                aNumberHasSwapped = false;
                for (int i = 0; i < length-1; i++)
                {
                    if(pupils[i].GetCatalogNr() > pupils[i + 1].GetCatalogNr())
                    {
                        temp = pupils[i].GetCatalogNr();
                        pupils[i].SetCatalogNr(pupils[i + 1].GetCatalogNr());
                        pupils[i + 1].SetCatalogNr(temp);
                        aNumberHasSwapped = true;
                    }
                }
                length = length - 1;

            } while (aNumberHasSwapped);

            Console.WriteLine("Sortierung nach KatalogNr abgeschlossen.");
            Acknowledge();
        }

        private static void PrintOutTableHeader()
        {
            string tableHeader = string.Format("{0,10} | {1,-20} | {2,-20} | {3,5}", "Katalog-Nr", "Vorname", "Nachname", "Plz");
            Console.Clear();
            Console.WriteLine(tableHeader);
            for (int i = 0; i < tableHeader.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        public static void PrintOutPupilsArray(ref Pupil[] pupils)
        {
            PrintOutTableHeader();
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

            PrintOutTableHeader();
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
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("1: Neuen Schüler anlegen");
                Console.WriteLine("2: Liste nach Katalognummer sortieren");
                Console.WriteLine("3: Liste nach Nachnamen sortieren");
                Console.WriteLine("4: Ausgabe der Liste");
                Console.WriteLine("5: Schüler je Postleitzahl ausgeben");
                Console.WriteLine("0: ENDE");
                Console.WriteLine("-------------------------------------");
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
                        BubbleSortPupilsArrayByCatalogNr(ref pupils);
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
