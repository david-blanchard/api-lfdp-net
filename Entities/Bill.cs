using System.Collections.Generic;

namespace LaFoireDesPrix.Entities;

public class Bill : ITimestampedEntity
{
    public int Id { get; set; }
    public decimal Vat { get; set; }
    public User? Client { get; set; }
    public ICollection<BillLineProduct> BillLines { get; } = new List<BillLineProduct>();
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public void AddBillLine(BillLineProduct line)
    {
        if (!BillLines.Contains(line))
        {
            BillLines.Add(line);
            line.Bill = this;
        }
    }

    public void RemoveBillLine(BillLineProduct line)
    {
        if (BillLines.Remove(line) && line.Bill == this)
        {
            line.Bill = null;
        }
    }
}
