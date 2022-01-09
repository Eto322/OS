namespace OC_LAB3;

public class Memory
{
    public PhysicalPage[] physicalPages = new PhysicalPage[7];

   public void print()
    {
        for (int i = 0; i < 86; i++)
        {
            Console.Write("-");
        }

        Console.WriteLine();

        foreach (PhysicalPage page in physicalPages)
        {
            if (page != null)
            {
                String time = page.time.DateTime.ToString("HH:mm:ss");
                Console.WriteLine(
                    $"Process {page.processNum}| Section {page.secNum}| Page{page.virtualPage.number}| {time}");
            }
            else
            {
                Console.WriteLine();
            }
        }

        for (int i = 0; i < 86; i++)
        {
            Console.Write("-");
        }
    }

   public Page getPage(Page page)
    {
        for (int i = 0; i < physicalPages.Length; i++)
        {
            if (physicalPages[i] != null && physicalPages[i].virtualPage == page)
            {
                return page;
            }
        }

        return null;
    }

   public bool IsFull()
    {
        foreach (PhysicalPage physicalPage in physicalPages)
        {
            if (physicalPage == null) return false;
        }


        return true;

    }

   public void removePage(Page page)
    {
        for (int i = 0; i < physicalPages.Length; i++)
        {
            if (physicalPages[i] != null && physicalPages[i].virtualPage ==
                page)
            {
                physicalPages[i] = null;
                page.physical_number = Int32.MinValue;
                page.presence = 0;
                break;
            }
        }

    }

   public void removeOldest()
    {
        int oldesIndex = 0;
        DateTimeOffset time = physicalPages[0].time;
        for (int i = 0; i < physicalPages.Length; i++)
        {
            var compare = DateTimeOffset.Compare(time, physicalPages[i].time);
            if (compare < 0)
            {
                oldesIndex = i;
                time = physicalPages[i].time;
            }
        }

        physicalPages[oldesIndex].virtualPage.presence = 0;
        physicalPages[oldesIndex] = null;
    }

   public void removeProcess(int index)
    {
        for (int i = 0; i < physicalPages.Length; i++)
        {
            if (physicalPages[i] != null && physicalPages[i].processNum ==
                index)
            {
                physicalPages[i].virtualPage.physical_number = Int32.MinValue;
                physicalPages[i].virtualPage.presence = 0;
                physicalPages[i] = null;
            }
        }
    }

   public void addPage(int process, int section, Page page)
    {
       
        if (IsFull())
        {
            removeOldest();
        }
        for (int i = 0; i < physicalPages.Length; i++)
        {
            if (physicalPages[i] == null)
            {
                physicalPages[i] = new PhysicalPage(process, section, page);
                page.physical_number = i;
                page.presence = 1;
                break;
            }
        }
    }
}

