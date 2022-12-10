namespace AoC._2022._10;

internal class Addx : ICommand
{
    public Addx(int toAdd)
    {
        ToAdd = toAdd;
    }

    public int Cycles { get; private set; } = 2;
    public int ToAdd { get; init; }

    public int Execute(int n)
    {
        var result = Cycles == 1 ? n + ToAdd : n;
        Cycles--;

        return result;
    }

    public override string ToString() => $"ADDX {ToAdd} {Cycles}";
}