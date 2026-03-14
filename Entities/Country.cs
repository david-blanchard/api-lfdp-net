using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaFoireDesPrix.Entities;

public class Country
{
    [Key]
    public string Code { get; set; } = "FR";
    public string Name { get; set; } = "France";
    public ICollection<City> Cities { get; } = new List<City>();

    public void AddCity(City city)
    {
        if (!Cities.Contains(city))
        {
            Cities.Add(city);
            city.Country = this;
        }
    }

    public void RemoveCity(City city)
    {
        if (Cities.Remove(city) && city.Country == this)
        {
            city.Country = null;
        }
    }
}
