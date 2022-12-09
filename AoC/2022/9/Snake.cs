namespace AoC._2022._9;

public class Snake
{
    public Point H = new(0, 0);
    public Point T = new(0, 0);

    public Snake? Tail { get; set; }

    public HashSet<Point> TailMoves = new()
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
        H = H with { Y = H.Y + 1 };
        MoveTail();
    }

    public void Down()
    {
        H = H with { Y = H.Y - 1 };
        MoveTail();
    }

    public void Left()
    {
        H = H with { X = H.X - 1 };
        MoveTail();
    }

    public void Right()
    {
        H = H with { X = H.X + 1 };
        MoveTail();
    }

    private void MoveTail()
    {
        var y = T.Y;
        var x = T.X;

        switch (H.Y - T.Y)
        {
            case > 1:
            {
                y = T.Y + 1;
                if (Math.Abs(H.X - T.X) == 1)
                {
                    x = H.X;
                }

                break;
            }
            case < -1:
            {
                y = T.Y - 1;
                if (Math.Abs(H.X - T.X) == 1)
                {
                    x = H.X;
                }

                break;
            }
        }

        switch (H.X - T.X)
        {
            case > 1:
            {
                x = T.X + 1;
                if (Math.Abs(H.Y - T.Y) == 1)
                {
                    y = H.Y;
                }

                break;
            }
            case < -1:
            {
                x = T.X - 1;
                if (Math.Abs(H.Y - T.Y) == 1)
                {
                    y = H.Y;
                }

                break;
            }
        }

        T = new Point(x, y);

        TailMoves.Add(T);

        Tail?.MoveHead(T);
    }
}