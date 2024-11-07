using System;
using System.Text;
using System.Windows;

namespace zadanie3lab5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string originalText = OriginalTextBox.Text;
            int key;
            if (int.TryParse(KeyTextBox.Text, out key) && key <= 255)
            {
                string encryptedText = VernamEncrypt(originalText, (byte)key);
                EncryptedTextBox.Text = encryptedText;
            }
            else
            {
                MessageBox.Show("Введите ключ от 0 до 255.");
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string encryptedText = EncryptedTextBox.Text;
            int key;
            if (int.TryParse(KeyTextBox.Text, out key) && key <= 255)
            {
                string decryptedText = VernamEncrypt(encryptedText, (byte)key);
                DecryptedTextBox.Text = decryptedText;
            }
            else
            {
                MessageBox.Show("Введите ключ от 0 до 255.");
            }
        }

        private string VernamEncrypt(string input, byte key)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] outputBytes = new byte[inputBytes.Length];

            for (int i = 0; i < inputBytes.Length; i++)
            {
                outputBytes[i] = (byte)(inputBytes[i] ^ key);
            }

            return Encoding.ASCII.GetString(outputBytes);
        }
    }
}
