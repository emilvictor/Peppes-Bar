using System;
namespace Bar
{
    public class Bar
    {
        /*
         Jag börjar med att deklarera variablen size som ska användas i vektorn som initieras till baren.
         Jag ger size värdet 20 vilket innebär att vektorn kommer innehålla 20 element.
         Jag deklarerar även här variabeln pris och ger den värdet 20, detta är alltså priset/kostnaden för varje öl.
         */
        private static int size = 20;
        private string[] baren = new string[size];
        int pris = 20;

        /*
         Metoden Run() här nedan innehåller programmets huvudmeny och via switch/case så anropas respektive
         metod för att utföra de opertioner som man önskar.
         */
        public void Run()
        {
            int meny = 0;
            do
            {
                Console.WriteLine("Välkommen till ditt nya jobb som bartender på Peppes Bar, det är upp till dig att fylla baren innan vi slår upp portarna");
                Console.WriteLine("Gör ditt val i menyn");
                Console.WriteLine("[1] Lägga till öl");
                Console.WriteLine("[2] Skriva ut innehållet");
                Console.WriteLine("[3] Beräkna det totala värdet på baren och skriv ut på skärmen");
                Console.WriteLine("[0] Avsluta");

               // Try /catch ser till så att användaren bara använder  siffror.
                try
                {
                    meny = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hoppsan, det verkar som att du skrev ett ogiltigt tecken");
                }
                switch (meny)
                {
                    case 1:
                        AddBeer();
                        break;
                    case 2:
                        PrintBeer();
                        break;
                    case 3:
                        CalcTotal();
                        break;
                    case 0:
                        Console.WriteLine("avsluta");
                        break;
                    default:
                        Console.WriteLine();
                        break;

                }
            }
            while (meny != 0);

            
        }

        //Metod där användaren väljer en öl, denna öl returneras
        public string ChooseBeer()
        {

            Console.WriteLine("Välj din dryck");
            Console.WriteLine("[1] Staropramen");
            Console.WriteLine("[2] Erdinger");
            Console.WriteLine("[3] Carlsberg");
            Console.WriteLine("[4] Tuborg");

            
            
                string val = Console.ReadLine();


                string dryck = "";

                switch (val)
                {
                    case "1":
                        dryck = "Staropramen";
                        break;
                    case "2":
                        dryck = "Erdinger";
                        break;
                    case "3":
                        dryck = "Carlsberg";
                        break;
                    case "4":
                        dryck = "Tuborg";
                        break;
                    default:
                        Console.WriteLine("Tyvärr har vi inte denna dryck för tillfället");
                        break;
                }

                Console.WriteLine(dryck);

                return dryck;
               
        }

        //Metod som håller reda på antalet flaskor
        public int AntalFlaskor()
        {
            int flaskor = 0;
            foreach (var plats in baren)
            {
                if (plats != null)
                    flaskor++;

            }

                return flaskor;
        }

        //Metod som skriver ut innehållet i baren
        public void PrintBeer()
        {
            foreach (var dryck in baren)
            {
                if (dryck != null)
                    Console.WriteLine(dryck);
                else
                    Console.WriteLine("Tom plats");
            }
        }

        //Metod som lägger till vald dryck om det finns en tom position
        public void AddBeerOnPosition(string dryck, int position)
        {
            if (baren.Length > position)
                baren[position] = dryck;
            else
                Console.WriteLine("Baren är inte tillräckligt stor, ange en giltig position");
        }

        //Metod som kollar om det finns en ledig plats i vektorn
         public int GetNextEmptyPosition()
         {
           for (int i = 0; i < baren.Length; i++)
           {
               if (baren[i] == null)
                   return i;
               
           }
            Console.WriteLine("Ingen tom position hittades");
            return -1;
         }

        //Hittar tom position, väljer dryck och lägger till på position
        public void AddBeer()
        {

            int position = GetNextEmptyPosition();

            if (position == -1)
                return;

            string dryck = ChooseBeer();

            //Kontrollerar så att dryck inte är tom. Om den är tom så skriv ut meddelande och returnera
            if (dryck == "")
            {
                Console.WriteLine("Du har skrivit in ett felaktigt svar, försök igen");
                return;
            }
            

            AddBeerOnPosition(dryck, position);

            if (AntalFlaskor() == size)
            {
                Console.WriteLine("Baren är nu full, släpp in gästerna!");
            }

        }

        //Metod som räknar ut det sammalagda värdet på baren och skriver ut det på skärmen
        public int CalcTotal()
        {
            int sum = 0;
            int flaskor = AntalFlaskor();

            sum = flaskor * 5;
           
            

            
            Console.WriteLine("Totala värdet av baren är nu " + sum + " kr");
            return sum;
        }
        

    }
}
