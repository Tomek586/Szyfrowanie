// MainWindow.xaml.cs
using System;
using System.Windows;
using System.Windows.Controls;

namespace Szyfrowanie
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = TextInput.Text;
            string selectedCipher = (CipherSelection.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (!string.IsNullOrEmpty(selectedCipher))
            {
                string outputText = "";

                switch (selectedCipher)
                {
                    case "Cezar":
                        int cezarShift = GetShiftFromUser();
                        outputText = CezarCipher.Encrypt(inputText, cezarShift);
                        break;

                    case "Polibiusz":
                        outputText = PolibiusCipher.Encrypt(inputText);
                        break;

                    case "Playfair":
                        outputText = PlayfairCipher.Encrypt(inputText);
                        break;

                    case "Homofoniczny":
                        outputText = HomofonicCipher.Encrypt(inputText);
                        break;

                    case "Polibiusz+":
                        outputText = PolibiusSquaredCipher.Encrypt(inputText);
                        break;

                    default:
                        break;
                }

                OutputText.Text = outputText;
            }
            else
            {
                MessageBox.Show("Wybierz szyfr przed szyfrowaniem.");
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = TextInput.Text;
            string selectedCipher = (CipherSelection.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (!string.IsNullOrEmpty(selectedCipher))
            {
                string outputText = "";

                switch (selectedCipher)
                {
                    case "Cezar":
                        int cezarShift = GetShiftFromUser();
                        outputText = CezarCipher.Decrypt(inputText, cezarShift);
                        break;

                    case "Polibiusz":
                        outputText = PolibiusCipher.Decrypt(inputText);
                        break;

                    case "Playfair":
                        outputText = PlayfairCipher.Decrypt(inputText);
                        break;

                    case "Homofoniczny":
                        outputText = HomofonicCipher.Decrypt(inputText);
                        break;

                    case "Polibiusz+":
                        outputText = PolibiusSquaredCipher.Decrypt(inputText);
                        break;

                    default:
                        break;
                }

                OutputText.Text = outputText;
            }
            else
            {
                MessageBox.Show("Wybierz szyfr przed odszyfrowywaniem.");
            }
        }

        private void EncryptWithCustomShiftButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = TextInput.Text;
            string outputText = CezarCipher.EncryptWithCustomShift(inputText);
            OutputText.Text = outputText;
        }

        private void CipherSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obsługa zmiany wybranego szyfru
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                string selectedCipher = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();

                // Tutaj możesz dodać kod do obsługi wybranego szyfru, na przykład zmieniając dostępność przycisków w zależności od wybranego szyfru.
                // ...
            }
        }

        private static int GetShiftFromUser()
        {
            int shift = 0;

            try
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Podaj przesunięcie:", "Przesunięcie Cezara", "", -1, -1);

                // Attempt to convert the input to an integer
                if (int.TryParse(input, out shift))
                {
                    // Check if the value is within the desired range
                    if (shift < 1 || shift > 34)
                    {
                        MessageBox.Show("Podano liczbę spoza zakresu 1-34. Wprowadź liczbę z tego zakresu.");
                        return GetShiftFromUser(); // Recursively call the method to get a valid input
                    }
                }
                else
                {
                    MessageBox.Show("Podano nieprawidłową liczbę. Wprowadź liczbę całkowitą.");
                    return GetShiftFromUser(); // Recursively call the method to get a valid input
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Podano nieprawidłową liczbę. Wprowadź liczbę całkowitą.");
                return GetShiftFromUser(); // Recursively call the method to get a valid input
            }

            return shift;
        }

    }
}
