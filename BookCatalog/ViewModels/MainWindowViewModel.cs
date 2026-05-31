using BookCatalog.Data;
using BookCatalog.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;


namespace BookCatalog.ViewModels

{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly BookContext db = new();

        public ObservableCollection<Book> Books { get; } = new();
        public ObservableCollection<Category> Categories { get; } = new();
        public ObservableCollection<Genre> Genres { get; } = new();

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private Category selectedCategory;

        public MainWindowViewModel()
        {
            LoadData();
        }
        private async void LoadData()
        {
            Books.Clear();
            Categories.Clear();
            Genres.Clear();


          
        }

        private void ApplyFilters()
        {
            IQueryable<Book> query = db.books;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                string lowerSearchText = searchText.ToLower();
                query = query.Where(p => p.Title.ToLower().Contains(lowerSearchText));

                if (selectedCategory != null && selectedCategory.Id != -1)
                {


                    if (selectedCategory != null && selectedCategory.Id != -1)
                    {
                        query = query.Where(p => p.Category.Id == selectedCategory.Id);
                    }



                    if (selectedCategory != null && selectedCategory.Id != -1)
                    {

                        query = query.Where(p => p.Category.Id == selectedCategory.Id);
                    }

                    Books.Clear();

                    foreach (var item in query.ToList())
                    {
                        Books.Add(item);
                    }

                }
            }
        }
    }
}

