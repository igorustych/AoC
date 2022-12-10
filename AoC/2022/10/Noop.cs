namespace AoC._2022._10;

internal class Noop : ICommand
{
    public int Cycles { get; private set; } = 1;

    public int Execute(int n)
    {
        Cycles--;
        return n;
    }

    public override string ToString() => $"NOOP {Cycles}";
}
