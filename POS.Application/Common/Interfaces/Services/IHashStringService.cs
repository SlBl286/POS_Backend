namespace POS.Application.Common.Interfaces.Services;

public interface IHashStringService
{
    string HashString(string key);
    string HashPassword(string key, out byte[] salt);
    /// <summary>
    /// return true if password is right
    /// </summary>
    bool VerifyPassword(string password, string hashedPassword, byte[] salt);
}