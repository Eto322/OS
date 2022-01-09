namespace OC_LAB3;

public class Section
{
    public int number;
    public Page [] pages;

    public Section(int number, Page[] pages)
    {
        this.number = number;
        this.pages = pages;
    }

   public void print()
    {
        Console.WriteLine($"Section# {number}");
        foreach (var page in pages)
        {
            page.print();
        }
    }
}