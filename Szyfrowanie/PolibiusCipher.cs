
public class PolibiusCipher
{
    private static readonly char[,] PolishAlphabetGrid = {
        {'A', 'Ą', 'B', 'C', 'Ć'},
        {'D', 'E', 'Ę', 'F', 'G'},
        {'H', 'I', 'J', 'K', 'L'},
        {'Ł', 'M', 'N', 'Ń', 'O'},
        {'Ó', 'P', 'Q', 'R', 'S'},
        {'Ś', 'T', 'U', 'V', 'W'},
        {'X', 'Y', 'Z', 'Ź', 'Ż'}
    };

    public static string Encrypt(string input)
    {
        input = input.ToUpper();
        string result = "";
        foreach (char c in input)
        {
            for (int i = 0; i < PolishAlphabetGrid.GetLength(0); i++)
            {
                for (int j = 0; j < PolishAlphabetGrid.GetLength(1); j++)
                {
                    if (PolishAlphabetGrid[i, j] == c)
                    {
                        result += (i + 1).ToString() + (j + 1).ToString() + " ";
                    }
                }
            }
        }
        return result.Trim();
    }

    public static string Decrypt(string input)
    {
        string[] pairs = input.Split(' ');
        string result = "";
        foreach (string pair in pairs)
        {
            if (pair.Length == 2)
            {
                int row = int.Parse(pair[0].ToString()) - 1;
                int col = int.Parse(pair[1].ToString()) - 1;
                result += PolishAlphabetGrid[row, col];
            }
        }
        return result;
    }
}
