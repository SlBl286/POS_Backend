namespace POS.Infrastrcture.Persistence;


public class DbSettings
{
    public const string SectionName = "ConnectionStrings";
    public string POSDb { get; init; } = null!;

}