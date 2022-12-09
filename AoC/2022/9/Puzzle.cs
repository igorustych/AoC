namespace AoC._2022._9;

internal class Puzzle
{
    public static int Run()
    {
        var input = File.ReadAllLines("2022/9/input.txt").Select(x => new Move
        {
            Direction = x.Split(' ')[0],
            Distance = int.Parse(x.Split(' ')[1])
        });

        var front = new Snake();
        var tail = front;
        for (var i = 0; i < 8; i++)
        {
            tail.Tail = new Snake();
            tail = tail.Tail;
        }

        foreach (var move in input)
        {
            switch (move.Direction)
            {
                case "U":
                {
                    for (var i = 0; i < move.Distance; i++)
                    {
                        front.Up();
                    }

                    break;
                }
                case "D":
                {
                    for (var i = 0; i < move.Distance; i++)
                    {
                        front.Down();
                    }

                    break;
                }
                case "L":
                {
                    for (var i = 0; i < move.Distance; i++)
                    {
                        front.Left();
                    }

                    break;
                }
                case "R":
                {
                    for (var i = 0; i < move.Distance; i++)
                    {
                        front.Right();
                    }

                    break;
                }
            }
        }

        return tail.TailMoves.Count;
    }
}