using System.Text;

namespace SystemDesign_URLShortener.Helpers;

public static class HexConverter
{

    public static string ToHex(this byte[] bytes, bool upperCase)
    {
        StringBuilder result = new(bytes.Length * 2);

        for (int i = 0; i < bytes.Length; i++)
            result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

        return result.ToString();
    }
}
