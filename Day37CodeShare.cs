
public interface IFilm
    {
        string Title { get; set; }
        string Director { get; set; }
        int Year { get; set; }
    }

    // Updated IFilmLibrary with UpdateFilm for full CRUD
    public interface IFilmLibrary
    {
        void AddFilm(IFilm film);      // CREATE
        void UpdateFilm(IFilm film);   // UPDATE
        void RemoveFilm(string title); // DELETE
        List<IFilm> GetFilms();        // READ all
        List<IFilm> SearchFilms(string query); // READ filtered
        IFilm? GetFilmByTitle(string title); // READ single
        int GetTotalFilmCount();
    }

    public class Film : IFilm
    {
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int Year { get; set; }

        public override string ToString()
        {
            return $"\"{Title}\" by {Director} ({Year})";
        }
    }

    // FilmLibrary now uses Dictionary<string, IFilm> (Title as key)
    public class FilmLibrary : IFilmLibrary
    {
        private readonly Dictionary<string, IFilm> _films = new Dictionary<string, IFilm>(StringComparer.OrdinalIgnoreCase);

        public void AddFilm(IFilm film)
        {
            if (string.IsNullOrEmpty(film.Title))
                throw new ArgumentException("Title cannot be empty");

            if (_films.ContainsKey(film.Title))
                throw new InvalidOperationException($"Film '{film.Title}' already exists");

            _films[film.Title] = film;
            Console.WriteLine($"✅ Added: {film}");
        }

        public void UpdateFilm(IFilm film)
        {
            if (string.IsNullOrEmpty(film.Title))
                throw new ArgumentException("Title cannot be empty");

            if (_films.ContainsKey(film.Title))
            {
                _films[film.Title] = film;  // Overwrite existing
                Console.WriteLine($"✅ Updated: {film}");
            }
            else
            {
                throw new KeyNotFoundException($"Film '{film.Title}' not found for update");
            }
        }

        public void RemoveFilm(string title)
        {
            if (_films.Remove(title))
            {
                Console.WriteLine($"🗑️ Removed: {title}");
            }
            else
            {
                Console.WriteLine($"❌ Film '{title}' not found.");
            }
        }

        public List<IFilm> GetFilms()
        {
            return _films.Values.ToList(); // LINQ on Values [web:43]
        }

        public IFilm? GetFilmByTitle(string title)
        {
            _films.TryGetValue(title, out var film);
            return film;
        }

        public List<IFilm> SearchFilms(string query)
        {
            return _films.Values
                .Where(f =>
                    f.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    f.Director.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    f.Year.ToString().Contains(query))
                .ToList(); // LINQ search on dictionary values [web:20]
        }

        public int GetTotalFilmCount()
        {
            return _films.Count;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IFilmLibrary library = new FilmLibrary();

            // CREATE (AddFilm) - CRUD
            library.AddFilm(new Film { Title = "Inception",        Director = "Christopher Nolan", Year = 2010 });
            library.AddFilm(new Film { Title = "The Godfather",    Director = "Francis Ford Coppola", Year = 1972 });
            library.AddFilm(new Film { Title = "Pulp Fiction",     Director = "Quentin Tarantino", Year = 1994 });
            library.AddFilm(new Film { Title = "Schindler's List", Director = "Steven Spielberg", Year = 1993 });
            library.AddFilm(new Film { Title = "Dunkirk",          Director = "Christopher Nolan", Year = 2017 });

            Console.WriteLine($"\n📊 Total films: {library.GetTotalFilmCount()}");

            // READ all
            Console.WriteLine("\n--- All Films (READ) ---");
            foreach (var film in library.GetFilms())
            {
                Console.WriteLine(film);
            }

            // READ single by title
            Console.WriteLine("\n--- Get single film (READ) ---");
            var godfather = library.GetFilmByTitle("The Godfather");
            Console.WriteLine(godfather ?? "Not found");

            // UPDATE (UpdateFilm) - CRUD
            Console.WriteLine("\n--- UPDATE Demo ---");
            var updatedGodfather = new Film { Title = "The Godfather", Director = "Francis Ford Coppola (Updated)", Year = 1972 };
            library.UpdateFilm(updatedGodfather);

            // DELETE (RemoveFilm) - CRUD
            Console.WriteLine("\n--- DELETE Demo ---");
            library.RemoveFilm("Pulp Fiction");

            Console.WriteLine($"\n📊 After UPDATE/DELETE: {library.GetTotalFilmCount()}");

            // SEARCH (LINQ on dictionary values)
            Console.WriteLine("\n--- Search 'Nolan' ---");
            var nolanFilms = library.SearchFilms("Nolan");
            foreach (var film in nolanFilms)
            {
                Console.WriteLine(film);
            }

            // LINQ demos on dictionary values (bonus)
            Console.WriteLine("\n--- LINQ on Dictionary Values ---");
            var recentFilms = library.GetFilms()
                .Where(f => f.Year >= 2010)
                .OrderByDescending(f => f.Year)
                .Take(2);
            foreach (var film in recentFilms)
            {
                Console.WriteLine($"Recent: {film}");
            }

            Console.WriteLine("\nDone. Press any key...");
            Console.ReadKey();
        }
    }
