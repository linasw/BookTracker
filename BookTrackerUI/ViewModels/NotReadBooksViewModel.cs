using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrackerUI.ViewModels
{
    public class NotReadBooksViewModel : Screen
    {
        BookTrackerDBEntities db;
        private BindableCollection<Book> _books;

        public NotReadBooksViewModel()
        {
            db = new BookTrackerDBEntities();
            _books = new BindableCollection<Book>();
        }

        public BindableCollection<Book> Books
        {
            get
            {
                var tempBooks = db.Books.Where(x => x.IsRead == false).ToList();
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
