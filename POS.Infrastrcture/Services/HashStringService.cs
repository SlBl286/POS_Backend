using System.Security.Cryptography;
using System.Text;
using POS.Application.Common.Interfaces.Services;

namespace POS.Infrastrcture.Services;

public class HashStringService : IHashStringService
{
    private readonly int _keySize = 64;
    private readonly int _iterations = 350000;
    private readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512; 
    public string HashPassword(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(_keySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            _iterations,
            _hashAlgorithm,
            _keySize);
        return Convert.ToHexString(hash);
    }

    public string HashString(string key)
    {
        throw new NotImplementedException();
    }
}