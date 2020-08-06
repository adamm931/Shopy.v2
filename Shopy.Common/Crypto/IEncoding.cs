namespace Shopy.Common.Interfaces
{
    public interface IEncoder
    {
        string Encode(string input);

        string Encode(byte[] input);

        string Decode(string input);
    }
}
