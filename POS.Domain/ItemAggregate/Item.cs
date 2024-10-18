using POS.Domain.Common.Models;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Domain.ItemAggregate;

public sealed class Item : AggregatetRoot<ItemId, Guid>
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Username { get; private set; }

    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public DateTime? Birthday { get; private set; }
    public string? Avatar { get; private set; }
    public string? Address { get; private set; }
    public string HashedPassword { get; private set; }
    private Item(ItemId id,
                 string firstName,
                 string lastName,
                 string username,
                 string? email,
                 string? phoneNumber,
                 DateTime birthday,
                 string? avatar,
                 string? address,
                 string hashedPassword) : base(id)
    {

        Username = username;
        Email = email;
        PhoneNumber = phoneNumber;
        Birthday = birthday;
        Avatar = avatar;
        Address = address;
        HashedPassword = hashedPassword;
    }

    public static Item Create(string firstName,
                              string lastName,
                              string username,
                              string? email,
                              string? phoneNumber,
                              DateTime birthday,
                              string? avatar,
                              string? address,
                              string hashedPassword)
    {
        return new Item(ItemId.CreateUnique(), firstName, lastName, username, email, phoneNumber, birthday, avatar, address, hashedPassword);
    }

#pragma warning disable CS0618
    private Item() { }
#pragma warning restore CS0618
}