namespace OC_LAB2;

public class FAT
{
    public Cluster[] table = new Cluster[256];
    public File[] rootDirectory = new File[10];
    public int rootDirectorySize = 0;

    public FAT()
    {
        for (int i = 0; i < 256; i++)
        {
            table[i] = new Cluster(i);
        }
    }

    public void printClusters()
    {

        for (int i = 0; i < 86; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();

        Console.Write("       ");
        for (int i = 0; i < 16; i++)
        {
            Console.Write("0x{0:X2} ",i);
        }
        Console.WriteLine();

        for (int i = 0; i < 86; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();

        for (int i = 0; i < table.Length; i++)
        {
            if (i%16==0)
            {
                Console.WriteLine();
                
                Console.Write("|0x{0:X2} |",i/16);
            }

            Console.Write("0x{0:X2} ",table[i].next);

        }
        Console.WriteLine();

    }

    public void printRootTable()
    {
        Console.Write("Root directory table:");
        Console.WriteLine();
        for (int i = 0; i < rootDirectory.Length; i++)
        {
            if (rootDirectory[i]!=null)
            {
               
                Console.WriteLine($"Index: {i} File Name: {rootDirectory[i].fileName}  first cluster : 0x{0:X2} " +
                                  $"Size: {rootDirectory[i].sizeCluster} clusters ", rootDirectory[i].firstCluster);
            }
        }
    }

    public void Test()
    {
        rootDirectory[rootDirectorySize] = new File("asd.txt", 0x70, 9);
        rootDirectorySize++;
        table[0x70].setNext(0x71);
        table[0x71].setNext(0x72);
        table[0x72].setNext(0x55);
        table[0x55].setNext(0x56);
        table[0x56].setNext(0x03);
        table[0x03].setNext(0x04);
        table[0x04].setNext(0x9C);
        table[0x9c].setNext(0x9D);
        table[0x9D].setNext(0xFF);

    }

    public int addCluster()
    {
        for (int i = 0; i < table.Length; i++)
        {
            if (table[i].next==0x00)
            {
                for (int j = i+1; j < table.Length; j++)
                {
                    if (table[j].next==0x00)
                    {
                        table[i].next = j;
                        return i;
                    }
                }
            }
        }
        return -1;
    }

    public void addLastCluster()
    {
        for (int i = 0; i < table.Length; i++)
        {
            if (table[i].next==0x00)
            {
                table[i].next = 0xFF;
                break;
                
            }
        }   
    }

    public void addClustersToExist(int index)
    {
        for (int i = 1; i < table.Length; i++)
        {
            if (table[i].next==0x00)
            {
                Console.WriteLine(rootDirectory[index].firstCluster);
                Console.WriteLine(i);
           

            table[i].next = rootDirectory[index].firstCluster;
            rootDirectory[index].firstCluster = i;
            rootDirectory[index].sizeCluster++;
            break;
            }

        }
    }

    public void addFile(int size, string name)
    {
        if (size<=0)
        {
            return;
        }

        rootDirectory[rootDirectorySize] = new File(name, addCluster(), size);
        rootDirectorySize++;

        for (int i = 0; i < size-2; i++)
        {
            addCluster();
        }
        addLastCluster();
    }

    public void increaseFile(int index, int number)
    {
        for (int i = 0; i < number; i++)
        {
            addClustersToExist(index);
        }
    }

  public  void deleteFile(int index)
  {
        int next = rootDirectory[index].firstCluster;
        do
        {
            int tmp = table[next].next;
            table[next].next = 0x00;
            next = tmp;
            rootDirectory[index].sizeCluster--;

        } while (rootDirectory[index].sizeCluster!=0);

        rootDirectory[index] = null;
  }

    public void printClustersArray(int index)
    {
        int current = rootDirectory[index].firstCluster;
        Console.Write($"Cluster array of file # {index} :");
        do
        {
            Console.Write("0x{0:X2} " , current);
            current = table[current].next;
        } while (current!=0xFF);
        Console.WriteLine();
    }

}