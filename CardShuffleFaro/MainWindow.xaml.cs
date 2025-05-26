using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CardShuffleApp
{
    public partial class MainWindow : Window
    {
        private List<Card> _initialCards = new();
        private List<Card> _currentCards = new();
        private Random _random = new();

        public MainWindow()
        {
            InitializeComponent();
            InitializeCards();
            UpdateCardsList(_currentCards);
        }

        private void InitializeCards()
        {
            var cards = new List<Card>
            {
                new Card { Key = 1, Name = "Туз" },
                new Card { Key = 2, Name = "Двойка" },
                new Card { Key = 3, Name = "Тройка" },
                new Card { Key = 4, Name = "Четвёрка" },
                new Card { Key = 5, Name = "Пятёрка" },
                new Card { Key = 6, Name = "Шестёрка" },
                new Card { Key = 7, Name = "Семёрка" },
                new Card { Key = 8, Name = "Восьмёрка" },
                new Card { Key = 9, Name = "Девятка" },
                new Card { Key = 10, Name = "Десятка" },
                new Card { Key = 11, Name = "Валет" },
                new Card { Key = 12, Name = "Дама" },
                new Card { Key = 13, Name = "Король" }
            };

            _initialCards = new List<Card>(cards);
            _currentCards = new List<Card>(_initialCards);
        }

        private void UpdateCardsList(IEnumerable<Card> cards)
        {
            CardsListBox.ItemsSource = null;
            CardsListBox.ItemsSource = cards;
        }

        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            _currentCards = _currentCards.OrderBy(c => _random.Next()).ToList();
            UpdateCardsList(_currentCards);
            SearchTextBox.Clear();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _currentCards = new List<Card>(_initialCards);
            UpdateCardsList(_currentCards);
            SearchTextBox.Clear();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            _currentCards = _currentCards.OrderBy(c => c.Name).ToList();
            UpdateCardsList(_currentCards);
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = SearchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(query))
            {
                UpdateCardsList(_currentCards);
                return;
            }

            var filtered = _currentCards.Where(c => c.Name.Contains(query, StringComparison.OrdinalIgnoreCase));
            UpdateCardsList(filtered);
        }
    }
}
