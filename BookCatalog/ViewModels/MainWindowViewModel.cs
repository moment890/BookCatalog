using BookCatalog.Data;
using BookCatalog.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookCatalog.ViewModels

{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly BookContext db = new();

        private List<Book> _allBooks { get; } = new();
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
            _allBooks.Clear();
            Categories.Clear();
            Genres.Clear();


            Categories.Add(new Category() { Id = -1, Name = "Все", Books = _allBooks });

        }

        partial void OnSearchTextChanged(string value)
        {
            ApplyFilters();
        }
        partial void OnSelectedCategoryChanged(Category value)
        {
            ApplyFilters();
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

                    _allBooks.Clear();

                    foreach (var item in query.ToList())
                    {
                        _allBooks.Add(item);
                    }

                }
            }
        }
    }
}

