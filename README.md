# MovieManager

---

## Description
ProjektObiektowe is a C# application designed for managing a database of movies, actors, and ratings. Users can add new movies, actors, and assign ratings to specific films, enabling effective cataloging and reviewing of a movie collection.

---

## Features
- Add new movies with details such as title, director, and release year.
- Add actors and associate them with movies.
- Assign ratings to movies for cataloging and evaluation.
- Store data in a local SQLite database.

---

## File Structure
```
ProjektObiektowe/
├── Migrations/
├── Models/
├── AddActorWindow.xaml
├── AddActorWindow.xaml.cs
├── AddFilmWindow.xaml
├── AddFilmWindow.xaml.cs
├── AddRatingWindow.xaml
├── AddRatingWindow.xaml.cs
├── App.xaml
├── App.xaml.cs
├── AppDbContext.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── ProjektObiektowe.csproj
├── ProjektObiektowe.sln
└── database.db
```

---

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/VvoiovV/ProjektObiektowe.git
   ```
2. Navigate to the project directory:
   ```bash
   cd ProjektObiektowe
   ```
3. Open the `ProjektObiektowe.sln` file in Visual Studio.
4. Build the solution by selecting "Build Solution" from the "Build" menu.
5. Run the application by selecting "Start" or pressing `F5`.

---

## System Requirements
- .NET Framework 4.7.2 or newer
- Visual Studio 2019 or newer
- SQLite

---

## Possible Improvements
- **User Interface**: Enhance the user interface for a better user experience.
- **Filtering and Sorting**: Add functionality to filter and sort movies by various criteria.
- **Data Export**: Enable exporting data to CSV or PDF formats.

---

If you have any questions or suggestions about the project, feel free to reach out via GitHub!
