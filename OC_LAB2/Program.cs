using System;

namespace OC_LAB2
{

    class Program
    {
        static void Main(string[] args)
        {
            Thread aThread = new Thread(new FirstThread().start);
            Thread bThread = new Thread(new SecondThread().start);
            aThread.Start();
            bThread.Start();

        }
    }

}

