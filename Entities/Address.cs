using System.Collections.Generic;

namespace LaFoireDesPrix.Entities;

public class Address
{
    public int Id { get; set; }
    public string Line1 { get; set; } = string.Empty;
    public string? Line2 { get; set; }
    public string? Details { get; set; }
    public City? City { get; set; }
    public ISet<User> Occupants { get; } = new HashSet<User>();

    public void AddOccupant(User occupant)
    {
        if (Occupants.Add(occupant))
        {
            occupant.AddAddressInternal(this);
        }
    }

    public void RemoveOccupant(User occupant)
    {
        if (Occupants.Remove(occupant))
        {
            occupant.RemoveAddressInternal(this);
        }
    }
}
