using POS.Domain.Common.Models;
using POS.Domain.GuestAggregate.ValueObjects;
using POS.Domain.ItemCategoryAggregate.Entities;
using POS.Domain.ItemCategoryAggregate.ValueObjects;

namespace POS.Domain.GuestAggregate;

public sealed class Guest : AggregatetRoot<GuestId, Guid>
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }
    public string? Email { get; private set; }
    public string? Address { get; private set; }
    public int? Gender { get; private set; }
    public int? YearOfBirth { get; private set; }


    private Guest(GuestId id,
        string code,
        string name,
        string phoneNumber,
        string? email,
        string? address,
        int? gender,
        int? yearOfBirth,
        DateTime? updatedAt,
        DateTime? createdAt
        ) : base(id)
    {
        Code = code;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        Gender = gender;
        YearOfBirth = yearOfBirth;
        if (updatedAt is not null)
            UpdatedAt = updatedAt.Value;
        if (createdAt is not null)
            CreatedAt = createdAt.Value;
    }

    public static Guest Create(GuestId id,
    string code,
    string name,
    string phoneNumber,
    string? email,
    string? address,
    int? gender,
    int? yearOfBirth, DateTime? updatedAt = null, DateTime? createdAt = null)
    {
        return new Guest(id, code, name, phoneNumber, email,address,gender,yearOfBirth, updatedAt, createdAt);
    }

#pragma warning disable CS0618
    private Guest() { }
#pragma warning restore CS0618
}