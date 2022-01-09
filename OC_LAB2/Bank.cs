namespace OC_LAB2;

public class Bank
{
    public Money[] BankMoneys =
    {
        new Money(50, 5),
        new Money(25, 10),
        new Money(10, 15),
        new Money(5, 20),
        new Money(2, 25),
        new Money(1, 50),

    };

    public List<Money> NeededMoneyList;

    public Bank()
    {
        NeededMoneyList = BankMoneys.ToList();
    }

    public void printBank()
    {
        Console.WriteLine("Our Money:");
        foreach (var money in NeededMoneyList)
        {
            Console.WriteLine($"{money._size} - {money._amount}");

        }
    }

    public bool getChange(int n)
    {
        for (int i = 0; i < BankMoneys.Length; i++)
        {
            double val = n / BankMoneys[i]._size;
            int needed =(int)Math.Floor(val);
            if (BankMoneys[i]._amount - needed < 0)
            {
                NeededMoneyList[i]._amount = BankMoneys[i]._amount;
            }
            else
            {
                NeededMoneyList[i]._amount = needed;

            }

            n -= BankMoneys[i]._size * NeededMoneyList[i]._amount;
        }

        if (n!=0)
        {
            return false;
        }

        for (int i = 0; i < BankMoneys.Length; i++)
        {
            BankMoneys[i]._amount -= NeededMoneyList[i]._amount;
        }

        return true;
    }
}