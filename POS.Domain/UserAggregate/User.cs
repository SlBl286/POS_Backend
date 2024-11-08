using POS.Domain.Common.Models;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Domain.UserAggregate;

public sealed class User : AggregatetRoot<UserId, Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Username { get; private set; }

    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public DateTime? Birthday { get; private set; }
    public string? Avatar { get; private set; }
    public string? Address { get; private set; }
    public string HashedPassword { get; private set; }
    public string Salt { get; private set; }
    public RefreshToken RefreshToken { get; private set; }
    private User(UserId id,
                 string firstName,
                 string lastName,
                 string username,
                 string? email,
                 string? phoneNumber,
                 DateTime? birthday,
                 string? avatar,
                 string? address,
                 string hashedPassword,
                 string salt,
                 RefreshToken refreshToken) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        PhoneNumber = phoneNumber;
        Birthday = birthday;
        Avatar = avatar;
        Address = address;
        HashedPassword = hashedPassword;
        Salt = salt;
        RefreshToken = refreshToken;
    }

    public static User Create(UserId id,
                            string firstName,
                              string lastName,
                              string username,
                              string? email,
                              string? phoneNumber,
                              DateTime? birthday,
                              string? avatar,
                              string? address,
                              string hashedPassword,
                              string salt,
                              RefreshToken refreshToken)
    {
        return new User(id, firstName, lastName, username, email, phoneNumber, birthday, avatar, address, hashedPassword, salt, refreshToken);
    }

#pragma warning disable CS0618
    private User() { }
#pragma warning restore CS0618
}