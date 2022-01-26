using System;

namespace ConsoleIS_20_03_L1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship ship1 = new Ship("Аврора", 40, 100, 10);
            Ship ship2 = new Ship("Решительный", 35, 250, 5);

            Random random = new Random();

            int step =0;
            while(true)
            {

                step++;
                ship1.Moving(random.Next(1, 50), IsRandon(random.Next(0, 2)));
                ship2.Moving(random.Next(1, 50), IsRandon(random.Next(0, 2)));

                Console.WriteLine(ship1.Info());
                Console.WriteLine(ship2.Info());

                Console.WriteLine($"ход {step}");
                Console.WriteLine (ship1.Atack(ship2));

               
                Console.WriteLine();

                if (!ship1.IsDrown() || !ship2.IsDrown())
                {
                    break;
                }
            }

            Console.Read();
        }

        private static bool IsRandon(int v)
        { 
            if(v == 0 )
            {
                return false;
            }

            return true;
        }
    }

}