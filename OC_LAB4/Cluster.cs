namespace OC_LAB2;

public class Cluster
{
    public int id { get; }
    public int next { get; set; }

    public Cluster(int id)
    {
        this.id = id;
        this.next = 0;
    }


    public void setNext(int i)
    {
        next = i;

    }
}