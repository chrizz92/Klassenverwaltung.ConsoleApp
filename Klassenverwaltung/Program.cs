using System;

namespace Klassenverwaltung
{
    class Program
    {
        private static void Acknowledge()
        {
            Console.WriteLine("----------------------------------------------------------------");
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
            Console.Clear();
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

        private static int GetLengthOfPupilArrayWithoutNull(ref Pupil[] pupils)
        {
            int length = 0;
            while (pupils[length] != null)
            {
                length++;
            }

            return length;
        }

        public static void BubbleSortPupilsArrayByCatalogNr(ref Pupil[] pupils)
        {
            Console.Clear();
            bool aNumberHasSwapped;
            Pupil temp;
            int length=GetLengthOfPupilArrayWithoutNull(ref pupils);
            
            do
            {
                aNumberHasSwapped = false;
                for (int i = 0; i < length-1; i++)
                {
                    if(pupils[i].GetCatalogNr() > pupils[i + 1].GetCatalogNr())
                    {
                        temp = pupils[i];
                        pupils[i] = pupils[i+1];
                        pupils[i + 1]= temp;
                        aNumberHasSwapped = true;
                    }
                }
                length = length - 1;

            } while (aNumberHasSwapped);

            Console.WriteLine("Sortierung nach KatalogNr abgeschlossen.");
            Acknowledge();
        }

        public static void BubbleSortPupilsArrayByLastName(ref Pupil[] pupils)
        {
            Console.Clear();
            bool aPupilHasSwapped;
            Pupil temp;
            int length = GetLengthOfPupilArrayWithoutNull(ref pupils);
            int stringComparisonResult;
            

            do
            {
                aPupilHasSwapped = false;
                for (int i = 0; i < length - 1; i++)
                {
                    stringComparisonResult = String.Compare(pupils[i].GetLastName(), pupils[i + 1].GetLastName());
                    if(stringComparisonResult==1)
                    {
                        temp = pupils[i];
                        pupils[i] = pupils[i + 1];
                        pupils[i + 1] = temp;
                        aPupilHasSwapped = true;
                    }
                }
                length = length - 1;

            } while (aPupilHasSwapped);

            Console.WriteLine("Sortierung nach Nachnamen abgeschlossen.");
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
            int length = GetLengthOfPupilArrayWithoutNull(ref pupils);
            PrintOutTableHeader();
            for (int i = 0; i < length; i++)
            {
                    Console.WriteLine("{0,10} | {1,-20} | {2,-20} | {3,5}", pupils[i].GetCatalogNr(), pupils[i].GetFirstName(), pupils[i].GetLastName(), pupils[i].GetZipCode());    
            }

            Acknowledge();
        }
        
        public static void PrintOutPupilIfLastNameMatches(ref Pupil[] pupils)
        {
            
            string lastName;
            int length = GetLengthOfPupilArrayWithoutNull(ref pupils);
            Console.Write("Welcher Nachname?: ");
            lastName = Console.ReadLine().ToLower().Trim();

            PrintOutTableHeader();
            for (int i = 0; i < length; i++)
            {
                    if (lastName == pupils[i].GetLastName().ToLower().Trim())
                    {
                        Console.WriteLine("{0,10} | {1,-20} | {2,-20} | {3,5}", pupils[i].GetCatalogNr(), pupils[i].GetFirstName(), pupils[i].GetLastName(), pupils[i].GetZipCode());
                    }
            }

            Acknowledge();
        }

        private static bool HasZipCodeUsedBefore(ref int[] usedZipCodes, int zipCodeToCheck)
        {
            bool hasZipCodeUsedBefore = false;
            for (int i = 0; i < usedZipCodes.Length; i++)
            {
                if (zipCodeToCheck == usedZipCodes[i])
                {
                    hasZipCodeUsedBefore = true;
                }
            }
            return hasZipCodeUsedBefore;
        }

        public static void PrintOutZipCodeStatistic(ref Pupil[] pupils)
        {
            Console.Clear();
            int length = GetLengthOfPupilArrayWithoutNull(ref pupils);
            int zipCode;
            int counter;
            int[] usedZipCodes = new int[length];
            for (int i = 0; i < length; i++)
            {
                counter = 0;
                zipCode = pupils[i].GetZipCode();
                
                if (HasZipCodeUsedBefore(ref usedZipCodes,zipCode))
                {

                }
                else
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (zipCode == pupils[j].GetZipCode())
                        {
                            counter++;
                        }
                    }
                    Console.WriteLine("In PLZ {0} wohnen {1,3} Schüler!", zipCode, counter);
                    usedZipCodes[i] = zipCode;
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
                Console.WriteLine("5: Schüler nach Nachnamen suchen");
                Console.WriteLine("6: Schüler je Postleitzahl ausgeben");
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
                        BubbleSortPupilsArrayByLastName(ref pupils);
                        break;
                    case 4:
                        PrintOutPupilsArray(ref pupils);
                        break;
                    case 5:
                        PrintOutPupilIfLastNameMatches(ref pupils);
                        break;
                    case 6:
                        //TODO
                        PrintOutZipCodeStatistic(ref pupils);
                        break;
                    case 0:
                        //EXIT PROGRAM
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe! Bitte nur Zahlen zwischen 0 und 6 eingeben.");
                        Console.Write("Bitte beliebige Taste zum Fortfahren drücken . . .");
                        Console.ReadKey();
                        break;
                }
            } while (menuNr != 0);
            
        }
    }
}
