using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaxelpengar_B
{
    class Program
    {
        static void Main(string[] args)
        {
            //Denna metod ska anropa metoderna ReadPositiveDouble och ReadUint för att läsa in totalsumman 
            //respektive erhållet belopp. Efter att ha beräknat belopp att betala, öresavrundningen, växeln tillbaka 
            //och skrivit ut ett kvitto ska metoden SplitIntoDenominations anropas. 

            uint subtotal = 0;
            double totalSum = 0;
            uint moneyRecieved = 0;
            double roundingOffAmount = 0;
            uint moneyBack = 0;

            do
            {
                totalSum = ReadPositiveDouble("Ange totalsumma:       ");

                subtotal = (uint)Math.Round(totalSum);          //Öresavrundning
                roundingOffAmount = totalSum - subtotal;        // ------"------

                moneyRecieved = ReadUint("Ange erhållet belopp: ", subtotal);

                moneyBack = moneyRecieved - subtotal;
                //Skriv ut belopp att betala, öresavrundning, växel tillbaka.
                Console.WriteLine();
                Console.WriteLine("-------------------------");
                Console.WriteLine("Totalsumma: {0}", totalSum);
                Console.WriteLine("Öresavrundning: {0}", roundingOffAmount);
                Console.WriteLine("Att betala: {0}", subtotal);
                Console.WriteLine("Kontant: {0}", moneyRecieved);
                Console.WriteLine("Tillbaka: {0}", moneyBack);
                Console.WriteLine("-------------------------");
                Console.WriteLine();
                //Sedan anropa SplitIntoDenominations

                SplitIntoDenominations(moneyBack);

                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Tryck tangent för ny räkning. Esc avslutar.");
                Console.WriteLine();
                Console.ResetColor();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
	{
	         
	}

        }

        static double ReadPositiveDouble(string prompt) 
        {
            string userInput = null;
            do
            {
                Console.Write(prompt);
                try
                {
                    userInput = Console.ReadLine();
                    if (double.Parse(userInput) >= 0.99)
                    {
                        break;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("FEL! '{0}' kan inte tolkas som en giltig summa pengar.", userInput);
                        Console.WriteLine();
                    }
                }
                catch
                {   
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("FEL! Erhållet belopp felaktigt.");
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);


            return double.Parse(userInput);
        }

        static uint ReadUint(string prompt, uint minValue)
        {
            string userInput = null;

            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
                try
                {
                    if (minValue < uint.Parse(userInput))
                    {
                        break;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("FEL! {0} kr är ett för litet belopp. Esc för att avsluta, ny tangent för nytt försök", userInput);
                        Console.WriteLine();
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("FEL! Erhållet belopp felaktigt.  Esc för att avsluta, ny tangent för nytt försök");
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            return uint.Parse(userInput);
        }

        static void SplitIntoDenominations(uint change) 
        {


            uint[] notes = new uint[7];
            notes[0] = 500;
            notes[1] = 100;
            notes[2] = 50;
            notes[3] = 20;
            notes[4] = 10;
            notes[5] = 5;
            notes[6] = 1;

            for (int i = 0; i < notes.Length; i++)
            {
                uint temporaryNoteValue = notes[i];
                notes[i] = change / temporaryNoteValue; 
                change = change % temporaryNoteValue;
                if (notes[i] > 0)
                {
                    Console.WriteLine("Antalet {0}-{1} är: {2}",
                        temporaryNoteValue, notes.Length < 4 ? "lappar" : "kronor", notes[i]);
                }
            }
            
                //                {
                //    while (notes[i] > 4)
                //    {
                //            Console.WriteLine("Antalet {0}-kronor är: {1}", temp, notes[i]);
                //            break;
                //    }
                //    while (notes[i] < 4)
                //    {
                //        Console.WriteLine("Antalet {0}-lappar är: {1}", temp, notes[6]);
                //        break;
                //    }
                //}


            //Console.WriteLine("Antalet 500-lappar är: {0}", notes[0]);
            //Console.WriteLine("Antalet 100-lappar är: {0}", notes[1]);
            //Console.WriteLine("Antalet 50-lappar är: {0}", notes[2]);
            //Console.WriteLine("Antalet 20-lappar är: {0}", notes[3]);
            //Console.WriteLine("Antalet 10-kronor är: {0}", notes[4]);
            //Console.WriteLine("Antalet 5-kronor är: {0}", notes[5]);
            //Console.WriteLine("Antalet 1-kronor är: {0}", notes[6]);
            //uint fiveH = change / notes[0];
            //change %= notes[0];
            //uint hunder = change / notes[1];
            //change %= notes[1];
            //uint fifty = change / notes[2];
            //change %= notes[2];
            //uint twenty = change / notes[3];
            //change %= notes[3];
            //uint tens = change / notes[4];
            //change %= notes[4];
            //uint fives = change / notes[5];
            //change %= notes[5];
            //uint ones = change / notes[6];
            //change %= notes[6];
        }

    }
}
