using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace WordScrambleGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> words = new List<string> { "arrays", "list", "algorithms", "sorting", "generics" };
        private string currentWord;
        private string scrambledWord;



        public MainWindow()
        {
            InitializeComponent();
        }



        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            currentWord = words[random.Next(words.Count)];
            scrambledWord = ScrambleWord(currentWord);
            wordLabel.Content = scrambledWord;
            answerTextBox.Clear();
        }



        private string ScrambleWord(string word)
        {
            char[] characters = word.ToCharArray();
            Random random = new Random();
            for (int i = characters.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = characters[i];
                characters[i] = characters[j];
                characters[j] = temp;
            }
            return new string(characters);
        }



        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.Equals(answerTextBox.Text, currentWord, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("CORRECT");
            }
            else
            {
                MessageBox.Show("INCORRECT");
            }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            answerTextBox.Clear();
        }



        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void CheckScoreButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement score tracking logic here
            MessageBox.Show("Score: 0"); // Placeholder
        }
    }
}