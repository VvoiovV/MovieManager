using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektObiektowe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
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
                
                var films = _context.Films.Include(f => f.Publisher).ToList();
                FilmsDataGrid.ItemsSource = films;
            }

        private void AddFilmButton_Click(object sender, RoutedEventArgs e)
        {
            var addFilmWindow = new AddFilmWindow();
            addFilmWindow.ShowDialog();
            LoadFilms(); // Refresh the DataGrid after adding a new film
        }
    }
    }

