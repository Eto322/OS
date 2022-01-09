using System;

namespace OC_LAB2
{

    class Program
    {
        private static void createFile(FAT fat)
        {
            Console.WriteLine("Input Name:");
            var name=Console.ReadLine();
            Console.WriteLine("Input size");
            var size = Convert.ToInt32(Console.ReadLine());
            fat.addFile(size,name);
            Console.WriteLine("File created");
            

        }

        private static void removeFile(FAT fat)
        {
            Console.WriteLine("Input Index");
            var index = Convert.ToInt32(Console.ReadLine());
            fat.deleteFile(index);
            Console.WriteLine("File removed");

        }

        private static void increaseFile(FAT fat)
        {
            Console.WriteLine("Input index: ");
            var index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input amount to increase");
            var amount=Convert.ToInt32(Console.ReadLine());
            fat.increaseFile(index,amount);
            Console.WriteLine("File increased");
        }

        private static void printClasters(FAT fat)
        {
            Console.WriteLine("Input index: ");
            var index=Convert.ToInt32(Console.ReadLine());
            fat.printClustersArray(index);
        }

        static void Main(string[] args)
        {


            FAT fat = new FAT();
            fat.Test();
            
            int n = 1;
            while (n != 0)
            {
               Console.WriteLine("1.Print Fat table");
               Console.WriteLine("2.Print directory");
               Console.WriteLine("3.Create file");
               Console.WriteLine("4.Increase size of file");
               Console.WriteLine("5.Remove File");
               Console.WriteLine("6.Print array of clusters");
               Console.WriteLine("9.Exit");
               n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        fat.printClusters();
                    break;
                    
                    case 2:
                        fat.printRootTable();
                        break;
                    case 3:
                        createFile(fat);
                        break;
                    case 4:
                        increaseFile(fat);
                        break;
                    case 5:
                        removeFile(fat);
                        break;
                    case 6:
                        printClasters(fat);
                        break;
                    default: break;
                }
        }


    }
    }

}