namespace OC_LAB3;

public class Processes
{
    private Process process1 = new Process(1,
        new Section[]
        {
            new Section(0, new Page[]
            {
                new Page(0, 0),
                new Page(1, 0),
                new Page(2, 0)
            }),
            new Section(1, new Page[]
            {
                new Page(0, 0),
                new Page(1, 0),
                new Page(2, 0)
            }),
            new Section(2, new Page[]
            {
                new Page(0, 0),
                new Page(1, 0),
                new Page(2, 0)
            })
        });

    private Process process2 = new Process(2,
        new Section[]
        {
            new Section(0, new Page[]
            {
                new Page(0, 0),
                new Page(1, 0),
                new Page(2, 0)
            }),
            new Section(1, new Page[]
            {
                new Page(0, 0),
                new Page(1, 0),
                new Page(2, 0)
            }),
            new Section(2, new Page[]
            {
                new Page(0, 0),
                new Page(1, 0),
                new Page(2, 0)
            })
        });

   public Process getProcess(int num)
    {
        switch (num)
        {
            case 1: return process1;
            case 2: return process2;
            default: throw new ArgumentException();
        }
    }

   public void printAll()
    {
        process1.print();
        process2.print();
    }



}