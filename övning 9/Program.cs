using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace övning_9
{
    class Program
    {
        static int vinnarX;
        static int vinnarY;
        static void Main(string[] args)
        {
            // Skapa spelplan
            string[,] gamePlan = SkapaSpelplan();
            SlumpPosition(gamePlan);
            RitaSpelplanTillSkärmen(gamePlan);

            bool isWinner = false;

            isWinner = PlayTheGame(gamePlan, isWinner);

            if (isWinner)
            {
                Console.WriteLine("Grattis du är en vinnare!");
            }
            Console.ReadLine();
        }

        private static bool PlayTheGame(string[,] gamePlan, bool isWinner)
        {
            while (!isWinner)
            {
                try
                {
                    int x, y;

                    Console.Write("Ange rad: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    x = x - 1;

                    Console.Write("Ange kolumn: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    y = y - 1;

                    isWinner = vinnarX == x && vinnarY == y;

                    if (!isWinner)
                        gamePlan[x, y] = "  *  ";
                    else
                        gamePlan[x, y] = "  O  ";

                    RitaSpelplanTillSkärmen(gamePlan);
                }

                catch(Exception ex)
                {
                    Console.WriteLine("Den koordinaten fanns ej");
                    Console.WriteLine(ex.Message);
                }
            }

            return isWinner;
        }

        private static void RitaSpelplanTillSkärmen(string[,] xxx)
        {
            Console.Clear();

            for (int i = 0; i < xxx.GetLength(0); i++)              //Skriver ut x ramen 1|2|3|4| överst
            {
                Console.Write("  ");
                Console.Write($"{i + 1}   |   ");
                Console.Write("  ");
            }
            Console.WriteLine("");

            for (int i = 0; i < xxx.GetLength(0); i++)                  //skriver ut 
            {

                Console.Write($" {i + 1}  |  ");

                for (int j = 0; j < xxx.GetLength(1); j++)              //Skriver ut alla X i rutorna samt 1|2|3|4| på sidan
                {
                    Console.Write($" {xxx[i, j]}  |  ");

                }
                Console.WriteLine("");
            }
            Console.WriteLine("--------------------------------------");
        }

        private static string[,] SkapaSpelplan()
        {
            int x, y;

            Console.Write("Ange antal rader: ");
            x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ange antal kolumner: ");
            y = Convert.ToInt32(Console.ReadLine());

            string[,] temp = new string[x, y];

            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = "  X  ";
                }
            }

            return temp;
        }

        private static void SlumpPosition(string[,] spelPlan)
        {
            Random random = new Random();

            int antalKolumner = spelPlan.GetLength(0);
            int antalRader = spelPlan.GetLength(1);

            int x = random.Next(0, antalKolumner);
            int y = random.Next(0, antalRader);

            vinnarX = x;
            vinnarY = y;
        }
    }
}
