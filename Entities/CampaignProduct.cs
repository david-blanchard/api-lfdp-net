namespace LaFoireDesPrix.Entities;

public class CampaignProduct
{
    public int Id { get; set; }
    public Campaign? Campaign { get; set; }
    public Product? Product { get; set; }
}
