namespace LaFoireDesPrix.Entities;

public class BillLineProduct
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public int Quantity { get; set; }
    public Bill? Bill { get; set; }
    public Product? Product { get; set; }
}
