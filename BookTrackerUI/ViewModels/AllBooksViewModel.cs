using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrackerUI.ViewModels
{
    public class AllBooksViewModel : Screen
    {
        BookTrackerDBEntities db;
        private BindableCollection<Book> _books;

        public AllBooksViewModel()
        {
            db = new BookTrackerDBEntities();
            _books = new BindableCollection<Book>();
        }

        public BindableCollection<Book> Books
        {
            get
            {
                var tempBooks = db.Books;
                _books = new BindableCollection<Book>(tempBooks);
                return _books;
            }
            set
            {
                _books = value;
                NotifyOfPropertyChange(() => Books);
            }
        }
    }
}
