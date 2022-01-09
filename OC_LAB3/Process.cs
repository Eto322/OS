namespace OC_LAB3;

public class Process
{
    public  int number;
    public  Section[] sections;

    public Process(int number, Section[] sections)
    {
        this.number = number;
        this.sections = sections;
    }

    public void print()
    {
        Console.WriteLine($"PROCESS# {number}");
        foreach (var section in sections)
        {
            section.print();
        }
    }
}