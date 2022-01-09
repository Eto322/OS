namespace OC_LAB3;

public class PhysicalPage
{
   public int processNum;
   public int secNum;
   public Page virtualPage;
   public DateTimeOffset time;

   public PhysicalPage(int processNum, int secNum, Page virtualPage)
   {
       this.processNum = processNum;
       this.secNum = secNum;
       this.virtualPage = virtualPage;
       time=DateTimeOffset.Now;
   }

}