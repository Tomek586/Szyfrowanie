using System;

public class PlayfairCipher
{
    private static readonly char[,] PlayfairMatrix = {
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
        input = input.ToUpper().Replace(" ", "");
        string result = "";

        for (int i = 0; i < input.Length; i += 2)
        {
            char firstChar = input[i];
            char secondChar = (i + 1 < input.Length) ? input[i + 1] : 'X';

            Tuple<int, int> firstCharPos = GetPositionInMatrix(firstChar);
            Tuple<int, int> secondCharPos = GetPositionInMatrix(secondChar);

            if (firstCharPos.Item1 == secondCharPos.Item1)
            {
                result += PlayfairMatrix[firstCharPos.Item1, (firstCharPos.Item2 + 1) % 5];
                result += PlayfairMatrix[secondCharPos.Item1, (secondCharPos.Item2 + 1) % 5];
            }
            else if (firstCharPos.Item2 == secondCharPos.Item2)
            {
                result += PlayfairMatrix[(firstCharPos.Item1 + 1) % 7, firstCharPos.Item2];
                result += PlayfairMatrix[(secondCharPos.Item1 + 1) % 7, secondCharPos.Item2];
            }
            else
            {
                result += PlayfairMatrix[firstCharPos.Item1, secondCharPos.Item2];
                result += PlayfairMatrix[secondCharPos.Item1, firstCharPos.Item2];
            }
        }

        return result;
    }

    public static string Decrypt(string input)
    {
        string result = "";

        for (int i = 0; i < input.Length; i += 2)
        {
            char firstChar = input[i];
            char secondChar = (i + 1 < input.Length) ? input[i + 1] : 'X';

            Tuple<int, int> firstCharPos = GetPositionInMatrix(firstChar);
            Tuple<int, int> secondCharPos = GetPositionInMatrix(secondChar);

            if (firstCharPos.Item1 == secondCharPos.Item1)
            {
                result += PlayfairMatrix[firstCharPos.Item1, (firstCharPos.Item2 - 1 + 5) % 5];
                result += PlayfairMatrix[secondCharPos.Item1, (secondCharPos.Item2 - 1 + 5) % 5];
            }
            else if (firstCharPos.Item2 == secondCharPos.Item2)
            {
                result += PlayfairMatrix[(firstCharPos.Item1 - 1 + 7) % 7, firstCharPos.Item2];
                result += PlayfairMatrix[(secondCharPos.Item1 - 1 + 7) % 7, secondCharPos.Item2];
            }
            else
            {
                result += PlayfairMatrix[firstCharPos.Item1, secondCharPos.Item2];
                result += PlayfairMatrix[secondCharPos.Item1, firstCharPos.Item2];
            }
        }

        return result;
    }

    private static Tuple<int, int> GetPositionInMatrix(char character)
    {
        for (int i = 0; i < PlayfairMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < PlayfairMatrix.GetLength(1); j++)
            {
                if (PlayfairMatrix[i, j] == character)
                {
                    return Tuple.Create(i, j);
                }
            }
        }

        return null;
    }
}
