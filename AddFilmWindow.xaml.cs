using ProjektObiektowe.Models;
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
using System.Windows.Shapes;

namespace ProjektObiektowe
{
    public partial class AddFilmWindow : Window
    {
        private readonly AppDbContext _context;

        public AddFilmWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        private void AddFilmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var film = new Film
                {
                    Name = NameTextBox.Text,
                    ProductionYear = int.Parse(ProductionYearTextBox.Text),
                    Publisher = new Publisher { CompanyName = PublisherTextBox.Text }
                };

                _context.Films.Add(film);
                _context.SaveChanges();
                MessageBox.Show("Film added successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding film: {ex.Message}");
            }
        }
    }
}