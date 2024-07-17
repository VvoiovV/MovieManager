using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;

namespace ProjektObiektowe
{
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
            LoadFilms();
        }

        private void LoadFilms()
        {
            var films = _context.Films
                .Include(f => f.Publisher)
                .Include(f => f.Ratings)
                .Include(f => f.FilmActors)
                    .ThenInclude(fa => fa.Actor)
                .ToList()
                .Select(f => new
                {
                    f.Id,
                    f.Name,
                    f.ProductionYear,
                    PublisherName = f.Publisher != null ? f.Publisher.CompanyName : "Unknown",
                    AverageRating = f.Ratings.Any() ? f.Ratings.Average(r => r.Rate).ToString("0.0") : "No ratings",
                    Actors = string.Join(", ", f.FilmActors.Select(fa => fa.Actor.Name))
                })
                .ToList();

            FilmsDataGrid.ItemsSource = films;
        }

        private void AddFilmButton_Click(object sender, RoutedEventArgs e)
        {
            var addFilmWindow = new AddFilmWindow();
            addFilmWindow.ShowDialog();
            LoadFilms();
        }

        private void AddRatingButton_Click(object sender, RoutedEventArgs e)
        {
            var addRatingWindow = new AddRatingWindow();
            addRatingWindow.ShowDialog();
            LoadFilms();
        }

        private void AddActorButton_Click(object sender, RoutedEventArgs e)
        {
            var addActorWindow = new AddActorWindow();
            addActorWindow.ShowDialog();
            LoadFilms();
        }
    }
}
