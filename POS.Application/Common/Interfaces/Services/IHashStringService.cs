namespace POS.Application.Common.Interfaces.Services;

public interface IHashStringService 
{
    string HashString(string key);
    string HashPassword(string key,out byte[] salt);
}