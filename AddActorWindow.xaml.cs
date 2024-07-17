using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using ProjektObiektowe.Models;

namespace ProjektObiektowe
{
    public partial class AddActorWindow : Window
    {
        private readonly AppDbContext _context;

        public AddActorWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();

            // Ładujemy filmy do ComboBoxa
            LoadFilms();
        }

        private void LoadFilms()
        {
            var films = _context.Films.ToList();
            FilmComboBox.ItemsSource = films;
        }

        private void AddActorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                string surname = SurnameTextBox.Text;
                DateTime birthDate = BirthDatePicker.SelectedDate ?? DateTime.MinValue;
                int selectedFilmId = (int)FilmComboBox.SelectedValue;

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Name is required.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(surname))
                {
                    MessageBox.Show("Surname is required.");
                    return;
                }

                if (birthDate == DateTime.MinValue)
                {
                    MessageBox.Show("Birth Date is required.");
                    return;
                }

                var actor = new Actor
                {
                    Name = name,
                    SurName = surname,
                    BirthDate = birthDate
                };

                _context.Actors.Add(actor);
                _context.SaveChanges();

                // Dodanie aktora do tabeli FilmActor
                var filmActor = new FilmActor
                {
                    FilmId = selectedFilmId,
                    ActorId = actor.Id
                };

                _context.FilmActors.Add(filmActor);
                _context.SaveChanges();

                MessageBox.Show("Actor added successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the actor: {ex.Message}");
            }
        }
    }
}
