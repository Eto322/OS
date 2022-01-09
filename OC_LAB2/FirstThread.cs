namespace OC_LAB2;

public class FirstThread
{
    public void start()
    {
        

        for (int i = 0; i < 30; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        Console.WriteLine("Here you can by tickets  to start press 0 ");
        for (int i = 0; i < 30; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        int input = Convert.ToInt32(Console.ReadLine());
        PostBox.signal=input;

        while (PostBox.signal!=9)
        {
            if (!PostBox.sent)
            {
                for (int i = 0; i < 30; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                Console.WriteLine("1.ticket to Kiev price 28 coins");
                Console.WriteLine("2.ticket to Moscow Price 37 coins");
                Console.WriteLine("3.ticket to London Price 50 coins");
                Console.WriteLine("4.ticket to Berlin Price 77 coins");
                Console.WriteLine("5.ticket to Paris Price 91 coins");
                Console.WriteLine("9.Exit");
               
                for (int i = 0; i < 30; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                Console.WriteLine("Select ticket");

                PostBox.signal = Convert.ToInt32(Console.ReadLine());

                if (PostBox.signal==9)
                {
                    break;
                }

                Console.WriteLine("Pass coins ");

                input = Convert.ToInt32(Console.ReadLine());
                int price = -1;
                bool wrongInput = false;

                switch (PostBox.signal)
                {
                    case 1:
                        price = 28;
                        break;
                    case 2:
                        price = 37;
                        break;
                    case 3:
                        price = 50;
                        break;
                    case 4:
                        price = 77;
                        break;
                    case 5:
                        price = 91;
                        break;
                    default:
                        wrongInput = true;
                        break;
                }

                if (wrongInput)
                {
                    Console.WriteLine("Wrong Input try again");
                    continue;
                }

                if (input-price<0)
                {
                    while (input-price<0)
                    {
                        Console.WriteLine("Not enough enter new sum of  money");
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                }

                PostBox.change = input - price;
                PostBox.sent = true;



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
        new Bank().printBank();

        
    }
}