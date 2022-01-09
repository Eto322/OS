namespace OC_LAB3;

public class Page
{
    public int number { get; }
    public int presence { get; set; }

    public int physical_number { get; set; }

    public Page(int number, int presence)
    {
        this.number = number;
        this.presence = presence;
       
    }

    public void setPhysical(int num)
    {
        physical_number = num;
    }

    public  void print()
    {
        Console.WriteLine($"Page {number} {presence} Physical:{physical_number}");
    }
}