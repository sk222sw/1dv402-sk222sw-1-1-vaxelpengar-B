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

            do
            {
                totalSum = ReadPositiveDouble("Ange totalsumma:       ");

                subtotal = (uint)Math.Round(totalSum);
                roundingOffAmount = totalSum - subtotal;

                moneyRecieved = ReadUint("Ange erhållet belopp: ", subtotal);


                Console.WriteLine(totalSum);
                Console.WriteLine(moneyRecieved);
                Console.WriteLine("Subtotal är {0}", subtotal);
                //Skriv ut belopp att betala, öresavrundning, växel tillbaka.
                //Sedan anropa SplitIntoDenominations

                SplitIntoDenominations(subtotal);
                Console.WriteLine("Tryck tangent för ny räkning. Esc avslutar.");
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
            uint subtotal;
            subtotal = change;
            uint[] notes = new uint[2];
            notes[0] = 0;       //100-lappar
            notes[1] = 0;       //1-kronor



            Console.WriteLine("100-lappar: {0}", notes[0]);
            Console.WriteLine("1-kronor: {0}", notes[1]);
        }

    }
}
