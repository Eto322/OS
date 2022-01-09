using System;

namespace OC_LAB3
{

    class Program
    {
        static void processPrint(Processes processes)
        {
            Console.WriteLine("Input number of process (or input 0 for print all processes):");
            var tmp = Convert.ToInt32(Console.ReadLine());
            if (tmp==0)
            {
                processes.printAll();
            }
            else
            {
                processes.getProcess(tmp);
            }
        }

        static void clearProcess(Processes processes, Memory memory)
        {
            Console.WriteLine("Input index of process");
            var tmp = Convert.ToInt32(Console.ReadLine());
            Process cProcess = processes.getProcess(tmp);
            memory.removeProcess(tmp);

        }

        static void processUnload(Processes processes, Memory memory)
        {
           
            Console.WriteLine("Input number of process: ");
            var tmp = Convert.ToInt32(Console.ReadLine());
            Process currentProc = processes.getProcess(tmp);

            Console.WriteLine("Input virtual address(XXXYYYCCC): ");
            String virtualAddr = Console.ReadLine();

            int sectionNum=Convert.ToInt32(virtualAddr.Substring(0,3));
            int pageNum=Convert.ToInt32(virtualAddr.Substring(3,3));

            Page currentPage=currentProc.sections[sectionNum].pages[pageNum];
            Console.WriteLine(currentPage.number);
            memory.removePage(currentPage);
            

          


        }

        static void processLoad(Processes processes, Memory memory)
        {

            Console.WriteLine("Input number of process: ");
            var n = Convert.ToInt32(Console.ReadLine());
            Process currentProc = processes.getProcess(n);
            Console.WriteLine("Input virtual address(XXXYYYCCC): ");
            
            String virtualAddr =Console.ReadLine();
            int sectionNum = Convert.ToInt32(virtualAddr.Substring(0, 3));
            int pageNum = Convert.ToInt32(virtualAddr.Substring(3, 3));

            Page currentPage = currentProc.sections[sectionNum].pages[pageNum];
            memory.addPage(n, sectionNum, currentPage);

            string binary = Convert.ToString(currentPage.physical_number,2);

            Console.WriteLine($"Physical addres: {binary}, {virtualAddr[6]} ");
          
        }

        static void getPhysicalAddres(Processes processes, Memory memory)
        {

            Console.WriteLine("Input number of process: ");
            var n = Convert.ToInt32(Console.ReadLine());

            Process currentProc = processes.getProcess(n);
            Console.WriteLine("Input virtual addr(XXXYYYCCC): ");

            String virtualAddr = Console.ReadLine();
            int sectionNum = Convert.ToInt32(virtualAddr.Substring(0, 3));
            int pageNum = Convert.ToInt32(virtualAddr.Substring(3, 3));


            Page currentPage = currentProc.sections[sectionNum].pages[pageNum];
            string binary = Convert.ToString(currentPage.physical_number,2);

            if (memory.getPage(currentPage) == null)
            {
                memory.addPage(n, sectionNum, currentPage);
                Console.WriteLine($"Page loaded just now. Physical addres: {binary} , {virtualAddr[6]}");
            }
            else
            {
                 Console.WriteLine($"Page alredy loaded just now. Physical addres: {binary} , {virtualAddr[6]}");
            }

        }

        static void Main(string[] args)
        {

            Memory memory = new Memory();
            Processes processes = new Processes();
           
          
            int temp = 1;
            while (temp != 0)
            {

                Console.WriteLine(" 1. Print operating memory");
                Console.WriteLine(" 2. Print process");
                Console.WriteLine(" 3. Load page of process");
                Console.WriteLine(" 4. Unload page of process");
                Console.WriteLine(" 5. Remove process");
                Console.WriteLine(" 6. Get physical addres");
                Console.WriteLine(" 0. Exit");


                temp = Convert.ToInt32(Console.ReadLine());
                switch (temp)
                {
                    case 1: memory.print(); break;
                    case 2: processPrint(processes); break;
                    case 3: processLoad(processes, memory); break;
                    case 4: processUnload(processes, memory); break;
                    case 5: clearProcess(processes, memory); break;
                    case 6: getPhysicalAddres(processes, memory); break;
                    default: break;
                }
            }
        }

    }
}

