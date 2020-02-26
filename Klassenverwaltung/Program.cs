﻿/**************************************************************************************************************************
 *  
 *  Übungsnr.:		23
 *	Programmname:	Klassenverwaltung
 *	Autor:			Christian SCHADLER
 *	Klasse:			4ABIF
 *	Datum:			26.02.2020
 *	
 *	-----------------------------------------------------------------------------------------------------------------------
 *
 *  Kurzbeschreibung:
 *	
 *	Eine einfache Schulklassenverwaltung. Die Daten eines einzelnen Schülers sind in einer eigenen Klasse Pupil mit den
 *	Feldern _catalogNr, _firstName, _lastName, _zipCode gespeichert.
 *  Die Schüler sind in einem Array vom Typ der Klasse Pupil mit der maximalen Anzahl von 40 gespeichert.
 *  Über ein Menü in der Main-Methode können mehrere Funktionen zur Bearbeitung des Arrays aufgerufen werden.
 *  
 **************************************************************************************************************************
 */

using System;

namespace Klassenverwaltung
{
    class Program
    {

        /// <summary>
        /// A private method that waits for users keypress before the programm goes on 
        /// </summary>
        private static void Acknowledge()
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.Write("Bitte beliebige Taste zum Fortfahren drücken . . .");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Takes a reference of an array of pupil and an index where a new pupil should be inserted.
        /// Calls a private method to create a new pupil and inserts the reference of the object at the given index of the array.
        /// </summary>
        /// <param name="pupils"></param>
        /// <param name="pupilsIndex"></param>
        public static void AddNewPupilToPupilsArray(ref Pupil[] pupils, ref int pupilsIndex)
        {
            pupils[pupilsIndex] = CreateNewPupil();
            Acknowledge();
        }

        /// <summary>
        /// A private method that creates a new instances of the class pupil and calls the 4 Set-Methods of the created object. 
        /// </summary>
        /// <returns>The created pupil object</returns>
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

        /// <summary>
        /// A private method that takes an array of pupil and checks how many indices are actually filled with a object reference.
        /// </summary>
        /// <param name="pupils"></param>
        /// <returns>The number of pupil references</returns>
        private static int GetLengthOfPupilArrayWithoutNull(ref Pupil[] pupils)
        {
            int length = 0;
            while (pupils[length] != null)
            {
                length++;
            }

            return length;
        }

        /// <summary>
        /// Takes the reference of an array of pupil and sorts the pupil objects in the array by their "_catalogNr"-field in ascending order
        /// </summary>
        /// <param name="pupils"></param>
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

        /// <summary>
        /// Takes the reference of an array of pupil and sorts the pupil objects in the array by their "_lastName"-field in ascending order.
        /// </summary>
        /// <param name="pupils"></param>
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

        /// <summary>
        /// A private method that prints out a table header for a table of pupil objects
        /// </summary>
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

        /// <summary>
        /// Takes the reference of an array of pupil and prints out a table of all included pupil objects
        /// </summary>
        /// <param name="pupils"></param>
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

        /// <summary>
        /// Takes the reference of an array of pupil and prints out a table of all pupil objects where the "_lastName"-field equals an asked lastname
        /// </summary>
        /// <param name="pupils"></param>
        public static void PrintOutPupilIfLastNameMatches(ref Pupil[] pupils)
        {
            int length = GetLengthOfPupilArrayWithoutNull(ref pupils);
            string lastName;
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

        /// <summary>
        /// A private method that takes a reference of an integer array with zipcodes and an integer with a zipcode and checks if the given integer is in the array or not.
        /// </summary>
        /// <param name="usedZipCodes"></param>
        /// <param name="zipCodeToCheck"></param>
        /// <returns>true if the zipCodeToCheck is in the array, else the method returns false</returns>
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

        /// <summary>
        /// Takes the reference of an array of pupil and prints for every "_zipCode"-field-value of the pupil objects out how often it occures  
        /// </summary>
        /// <param name="pupils"></param>
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
                        PrintOutZipCodeStatistic(ref pupils);
                        break;
                    case 0:
                        //EXIT PROGRAM
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe! Bitte nur Zahlen zwischen 0 und 6 eingeben.");
                        Console.Write("Bitte beliebige Taste zum Fortfahren drücken . . .");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            } while (menuNr != 0);
            
        }
    }
}
