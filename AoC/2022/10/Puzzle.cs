namespace AoC._2022._10
{
    public class Puzzle
    {
        public static void Run()
        {
            var commandBuilder = new CommandBuilder();
            var commands = File.ReadAllLines("2022/10/input.txt").Select(input => commandBuilder.Build(input)).ToList();

            var cycle = 1;
            var x = 1;

            var signalStrength = 0;

            foreach (var command in commands)
            {
                while (command.Cycles > 0)
                {
                    PrintCrt(cycle, x);

                    cycle++;

                    x = command.Execute(x);

                    if (cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140 || cycle == 180 || cycle == 220)
                    {
                        var running = cycle * x;
                        signalStrength += running;
                    }
                }
            }

            Console.WriteLine($"Signal strength: {signalStrength}");
        }
    
        private static void PrintCrt(int cycle, int spritePosition)
        {
            var x = cycle % 40 - 1;

            if (Math.Abs(x - spritePosition) <= 1)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(".");
            }

            if (cycle % 40 == 0)
            {
                Console.WriteLine();
            }
        }   
    }
}
