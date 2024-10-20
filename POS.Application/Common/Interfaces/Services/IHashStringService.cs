namespace POS.Application.Common.Interfaces.Services;

public interface IHashStringService 
{
    string HashString(string key);
    string HashPassword(string key, byte[] salt);
    bool VerifyPassword(string password,string hashedPassword, byte[] salt);

    byte[] GenerateSalt();
}