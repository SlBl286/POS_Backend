using System.Security.Cryptography;
using System.Text;
using POS.Application.Common.Interfaces.Services;

namespace POS.Infrastrcture.Services;

public class HashStringService : IHashStringService
{
    private readonly int _keySize = 64;
    private readonly int _iterations = 350000;
    private readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;

    public byte[] GenerateSalt(){
        return RandomNumberGenerator.GetBytes(_keySize);
    }
    public string HashPassword(string password,  byte[] salt)
    {
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            _iterations,
            _hashAlgorithm,
            _keySize);
        return Convert.ToHexString(hash);
    }
    
    public bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _hashAlgorithm, _keySize);
        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }
    public string HashString(string key)
    {
        throw new NotImplementedException();
    }
}