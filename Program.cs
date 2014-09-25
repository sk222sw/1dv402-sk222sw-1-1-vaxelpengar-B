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

            double totalSum = 0;
            uint moneyRecieved = 0;
            double roundingOffAmount = 0;
            uint toPay = 0;
            uint moneyBack = 0;

            totalSum = ReadPositiveDouble("Ange totalsumma: ");

            moneyRecieved = ReadUint("Ange erhållet belopp: ");

            Console.WriteLine(totalSum);
            Console.WriteLine(moneyRecieved);

        }

        static double ReadPositiveDouble(string prompt) 
        {
            string userInput = null;
            Console.WriteLine(prompt);
            userInput = Console.ReadLine();
            return double.Parse(userInput);
            //Metoden ska returnera ett värde av typen double.
            //Innan värdet returneras ska metoden säkerställa att användaren matat in ett värde som, efter 
            //avrundning, är större eller lika med 1. Om det inmatade inte kan tolkas som ett korrekt värde ska 
            //användaren få en chans att göra en ny inmatning.
            //Till metoden ska det vara möjligt att skicka en sträng med information som ska visas i anslutning till 
            //där inmatningen av värdet sker. I Figur B.3 har argumentet "Ange totalsumma : " skickats 
            //med vid anropet av metoden.
        }

        static uint ReadUint(string prompt)
        {
            string userInput = null;
            Console.WriteLine(prompt);
            userInput = Console.ReadLine();
            //Metoden ska returnera ett värde av typen uint. (Datatypen uint passar i detta fall då endast hela 
            //kronor motsvarande ett värde större än 0 ska hanteras.)
            //Innan värdet returneras ska metoden säkerställa att användaren matat in ett värde som är större eller 
            //lika med angivet minsta värde. Om det inmatade inte kan tolkas som ett korrekt värde ska användaren 
            //få en chans att göra en ny inmatning.
            //Till metoden ska det vara möjligt att skicka med två argument. Det första argument ska vara en sträng 
            //med information som ska visas i anslutning till där inmatningen av värdet sker. Det andra argumentet 
            //är det minsta värdet som är giltigt. I Figur B.4 har argumenten "Ange erhållet belopp: " och 538
            //skickats med vid anropet av metoden. 
            return uint.Parse(userInput);
        }

        static void SplitIntoDenominations() {}

    }
}
