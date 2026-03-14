namespace LaFoireDesPrix.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Zipcode { get; set; } = string.Empty;
    public Country? Country { get; set; }
}
