using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrackerUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        BookTrackerDBEntities db;

        public ShellViewModel()
        {
            db = new BookTrackerDBEntities();
        }

        public void LoadAllBooks()
        {
            ActivateItem(new AllBooksViewModel());
        }

        public void LoadReadBooks()
        {
            ActivateItem(new ReadBooksViewModel());
        }

        public void LoadNotReadBooks()
        {
            ActivateItem(new NotReadBooksViewModel());
        }

        public void AddNew()
        {
            //ADDS NEW BOOK
        }
    }
}
