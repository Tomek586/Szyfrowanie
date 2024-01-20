using System;
using System.Collections.Generic;

public class PolibiusSquaredCipher
{
    private static readonly char[,] PolibiusTable = {
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
            if (c == ' ')
            {
                result += ' ';
                continue;
            }
            for (int i = 0; i < PolibiusTable.GetLength(0); i++)
            {
                for (int j = 0; j < PolibiusTable.GetLength(1); j++)
                {
                    if (PolibiusTable[i, j] == c)
                    {
                        int row = i + 1;
                        int col = j + 1;
                        int squaredValue = row * 10 + col;

                        result += (squaredValue * squaredValue).ToString() + " ";
                    }
                }
            }
        }

        return result.Trim();
    }

    public static string Decrypt(string input)
    {
        string result = "";
        string[] pairs = input.Split(' ');

        foreach (string pair in pairs)
        {
            if (pair == "")
            {
                result += ' ';
                continue;
            }

            int decryptedValue = (int)Math.Sqrt(int.Parse(pair));
            int row = decryptedValue / 10 - 1;
            int col = decryptedValue % 10 - 1;

            if (row >= 0 && row < PolibiusTable.GetLength(0) && col >= 0 && col < PolibiusTable.GetLength(1))
            {
                result += PolibiusTable[row, col];
            }
        }

        return result;
    }
}