using System.Collections.Generic;
using LaFoireDesPrix.Enums;

namespace LaFoireDesPrix.Entities;

public class User
{
    public const string UserRole = "ROLE_USER";
    public const string AdminRole = "ROLE_ADMIN";

    private readonly HashSet<Address> _addresses = new();

    public int Id { get; set; }
    public UserGender Gender { get; set; } = UserGender.Male;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = "john.doe@example.com";
    public List<string> Roles { get; } = new() { UserRole };
    public string? Password { get; set; }
    public bool IsVerified { get; set; }
    public string? VerificationToken { get; set; }
    public IReadOnlyCollection<Address> Addresses => _addresses;

    public void SetRoles(IEnumerable<string> roles)
    {
        Roles.Clear();
        var unique = new HashSet<string>(roles) { UserRole };
        Roles.AddRange(unique);
    }

    public void AddAddress(Address address)
    {
        if (_addresses.Add(address))
        {
            address.Occupants.Add(this);
        }
    }

    public void RemoveAddress(Address address)
    {
        if (_addresses.Remove(address))
        {
            address.Occupants.Remove(this);
        }
    }

    internal void AddAddressInternal(Address address)
    {
        _addresses.Add(address);
    }

    internal void RemoveAddressInternal(Address address)
    {
        _addresses.Remove(address);
    }
}
