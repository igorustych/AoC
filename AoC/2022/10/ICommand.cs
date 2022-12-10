namespace AoC._2022._10;

internal interface ICommand
{
    int Cycles { get; }
    int Execute(int n);
}
