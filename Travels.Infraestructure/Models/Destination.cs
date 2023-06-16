namespace Travels.Infraestructure.Models;

public class Destination
{
    public int id { get; set; }
    public string name { get; set; }
    public int maxUsers { get; set; }
    public int isRisky { get; set; }
}