// CezarCipher.cs
using System;
using System.Windows;

public class CezarCipher
{
    private static readonly string PolishAlphabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUWVXYZŹŻ";

    public static string Encrypt(string input, int shift)
    {
        input = input.ToUpper();
        string result = "";

        foreach (char c in input)
        {
            if (PolishAlphabet.Contains(c.ToString()))
            {
                int index = (PolishAlphabet.IndexOf(c) + shift) % PolishAlphabet.Length;
                result += PolishAlphabet[index];
            }
            else
            {
                result += c;
            }
        }

        return result;
    }

    public static string Decrypt(string input, int shift)
    {
        return Encrypt(input, PolishAlphabet.Length - shift);
    }

    public static string EncryptWithCustomShift(string input)
    {
        int shift = GetShiftFromUser();
        return Encrypt(input, shift);
    }

    private static int GetShiftFromUser()
    {
        int shift = 0;
        try
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Podaj przesunięcie:", "Przesunięcie Cezara", "", -1, -1);
            shift = Convert.ToInt32(input);
        }
        catch (FormatException)
        {
            MessageBox.Show("Podano nieprawidłową liczbę. Wprowadź liczbę całkowitą.");
        }

        return shift;
    }
}
