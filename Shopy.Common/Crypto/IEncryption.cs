namespace Shopy.Common.Interfaces
{
    public interface IEncryption
    {
        string GenerateSalt();

        string Encrypt(string value);
    }
}
