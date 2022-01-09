namespace OC_LAB2;

public class SecondThread
{
    public void start()
    {
        while (PostBox.signal!=9)
        {
            if (PostBox.sent)
            {
                if (new Bank().getChange(PostBox.change))
                {
                    Console.WriteLine($"your Reminder {PostBox.change} and your ticket");

                }
                else
                {
                    Console.WriteLine("We didn't have that sum of reminder take your money back");

                }

                Console.WriteLine("If you want to buy another ticket press 0 . For exit press 9");
                PostBox.signal = Convert.ToInt32(Console.ReadLine());
                PostBox.sent = false;

            }

            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}