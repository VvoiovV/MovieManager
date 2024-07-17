using System;
using System.Windows;
using ProjektObiektowe.Models;

namespace ProjektObiektowe
{
    public partial class AddRatingWindow : Window
    {
        private readonly AppDbContext _context;

        public AddRatingWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        private void AddRatingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string userName = UserNameTextBox.Text;
                int filmId;
                int ratingValue;

                if (string.IsNullOrWhiteSpace(userName))
                {
                    MessageBox.Show("User Name is required.");
                    return;
                }

                if (!int.TryParse(FilmIdTextBox.Text, out filmId))
                {
                    MessageBox.Show("Film ID must be a valid integer.");
                    return;
                }

                if (!int.TryParse(RatingTextBox.Text, out ratingValue) || ratingValue < 1 || ratingValue > 5)
                {
                    MessageBox.Show("Rating must be a number between 1 and 5.");
                    return;
                }

                var rating = new Rating
                {
                    UserName = userName,
                    FilmId = filmId,
                    Rate = ratingValue
                };

                _context.Ratings.Add(rating);
                _context.SaveChanges();
                MessageBox.Show("Rating added successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the rating: {ex.Message}");
            }
        }
    }
}
