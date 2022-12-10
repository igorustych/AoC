namespace AoC._2022._10;

internal class CommandBuilder
{
    public ICommand Build(string input)
    {
        if (input == "noop")
        {
            return new Noop();
        }
        
        return new Addx(int.Parse(input.Split(' ')[1])); 
    }
}
