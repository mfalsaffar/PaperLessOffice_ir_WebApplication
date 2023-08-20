using System.ComponentModel.DataAnnotations;

public class MyJobViewModel
{
    [Key] // Dummy key annotation
    public int DummyKey { get; set; }

    public string Fullname { get; set; }
    public string ProcName { get; set; }
    public int WfId { get; set; }
    // Add other properties as needed
}
