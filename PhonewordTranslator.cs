using System.Text;

namespace Phoneword;

public class PhonewordTranslator
{
    static readonly string[] digits =
        {
            "ABC", "DEF", "GHI" ,"JKL" ,"MNO", "PQRS" , "TUV" , "WXYZ"
        };
    static StringBuilder sb = new StringBuilder();
    
    public static string ReceiveRaw(string raw)
    {
        sb.Clear();
        ScanCharacters(raw);
        return sb.ToString();
    }
    private static void ScanCharacters(string raw)
    {
        foreach (var currentChar in raw)
        {
            if (char.IsLetter(currentChar))
            {
                 char translatedChar = TranslateCharacter(currentChar);
                 AppendResult(translatedChar);
            }
            else if (char.IsDigit(currentChar))
            {
                AppendResult(currentChar);
            }
            else if (char.IsWhiteSpace(currentChar))
            {
                AppendResult(currentChar);
            }
            else if (currentChar == '-')
            {
                AppendResult(currentChar);
            }
            else 
                continue;
        }
    }

    private static char TranslateCharacter(char currentChar)
    {
        currentChar =  char.ToUpper(currentChar);
        foreach (var letterGroup in digits)
            {
                if (letterGroup.Contains(currentChar))
                {
                    int index = Array.IndexOf(digits, letterGroup);
                    int phoneDigit = index + 2;
                    return phoneDigit.ToString()[0];
                }
            }

        return currentChar;
    }
    
    private static void AppendResult(char c)
    {
        sb.Append(c);
    }
}

