namespace OC_LAB2;

public class File
{
    public string fileName { get; set; }
    public int firstCluster { get; set; }
    public int sizeCluster { get; set; }

    public File(string fileName, int firstCluster, int sizeCluster)
    {
        this.fileName = fileName;
        this.firstCluster = firstCluster;
        this.sizeCluster = sizeCluster;
    }


}