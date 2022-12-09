

Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("C:/temp/input.txt").Select(x => new Move
{
    Direction = x.Split(' ')[0],
    Distance = int.Parse(x.Split(' ')[1])
});


var snake = new Snake();
var running = snake;
for (var i = 0; i < 8; i++)
{
    running.Tail = new Snake();
    running = running.Tail;
}

foreach (var move in input)
{
    if(move.Direction == "U")
    {
        for(var i = 0; i < move.Distance; i++)
        {
            snake.Up();
        }
    }

    if (move.Direction == "D")
    {
        for (var i = 0; i < move.Distance; i++)
        {
            snake.Down();
        }
    }

    if (move.Direction == "L")
    {
        for (var i = 0; i < move.Distance; i++)
        {
            snake.Left();
        }
    }

    if (move.Direction == "R")
    {
        for (var i = 0; i < move.Distance; i++)
        {
            snake.Right();
        }
    }
}

var unique = new List<Point>();

foreach(var m in running.tailMoves)
{
    if(!unique.Any(x => x.X == m.X && x.Y == m.Y))
    {
        unique.Add(m);
    }
}




Console.WriteLine(unique.Count);






public class Snake
{
    public Point H = new Point(0, 0);
    public Point T = new Point(0, 0);

    public Snake Tail { get; set; }

    public List<Point> tailMoves = new List<Point>
    {
        new Point(0,0)
    };

    public void MoveHead(Point p)
    {
        H = p;
        MoveTail();
    }

    public void Up()
    {
        H = new Point(H.X, H.Y + 1);
        MoveTail();
    }

    public void Down()
    {
        H = new Point(H.X, H.Y - 1);
        MoveTail();
    }

    public void Left()
    {
        H = new Point(H.X - 1, H.Y);
        MoveTail();
    }

    public void Right()
    {
        H = new Point(H.X + 1, H.Y);
        MoveTail();
    }

    private void MoveTail()
    {
        int y = T.Y;
        int x = T.X;

        if (H.Y - T.Y > 1)
        {
            y = T.Y + 1;
            if (Math.Abs(H.X - T.X) == 1)
            {
                x = H.X;
            }
        }
        else if (H.Y - T.Y <-1)
        {
            y = T.Y - 1;
            if (Math.Abs(H.X - T.X) == 1)
            {
                x = H.X;
            }

        }

        if (H.X - T.X > 1)
        {
           x = T.X + 1;
            if (Math.Abs(H.Y - T.Y) == 1)
            {
                y = H.Y;
            }
        }
        else if (H.X -T.X < -1)
        {
            x = T.X - 1;
            if (Math.Abs(H.Y - T.Y) == 1)
            {
                y = H.Y;
            }
        }

        
        T = new Point(x, y);

        tailMoves.Add(T);

        if(Tail != null)
        {
            Tail.MoveHead(T);
        }
    }
}


public class Point 
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X;
    public int Y;

    public override string ToString()
    {
        return $"{X} {Y}";
    }
}

public class Move
{
    public string Direction { get; set; }
    public int Distance { get; set; }
}







