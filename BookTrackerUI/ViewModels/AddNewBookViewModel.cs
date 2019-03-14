using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookTrackerUI.ViewModels
{
    public class AddNewBookViewModel : Screen
    {
        private BookTrackerDBEntities dBEntities;
        private string _bookName;
        private string _authorName;
        private string _bookDescription;
        private DateTime _bookDate;

        public AddNewBookViewModel()
        {
            
        }

        public string BookName
        {
            get { return _bookName; }
            set
            {
                _bookName = value;
                NotifyOfPropertyChange(() => BookName);
            }
        }
        public string AuthorName
        {
            get { return _authorName; }
            set
            {
                _authorName = value;
                NotifyOfPropertyChange(() => AuthorName);
            }
        }
        public string BookDescription
        {
            get { return _bookDescription; }
            set
            {
                _bookDescription = value;
                NotifyOfPropertyChange(() => BookDescription);
            }
        }
        public DateTime BookDate
        {
            get { return _bookDate; }
            set
            {
                _bookDate = value;
                NotifyOfPropertyChange(() => BookDate);
            }
        }

        public void AddNew(string bookName, string authorName, string bookDescription, DateTime bookDate)
        {
            using (dBEntities = new BookTrackerDBEntities())
            {
                if (!(dBEntities.Books.Any(x => x.Name.Equals(bookName))))
                {
                    int authorId;
                    if (!(dBEntities.Authors.Any(x => x.FullName.Equals(authorName))))
                    {
                        Author author = new Author { FullName = authorName };
                        dBEntities.Authors.Add(author);
                        dBEntities.SaveChanges();

                        authorId = author.Id;
                    }

                    Author tempAuthor = dBEntities.Authors.First(x => x.FullName.Equals(authorName));
                    authorId = tempAuthor.Id;
                    Book book = new Book { Name = bookName, AuthorID = authorId, Description = bookDescription, PublishingDate = bookDate };

                    dBEntities.Books.Add(book);
                    dBEntities.SaveChanges();

                    MessageBox.Show("Book succesfully added!");
                    return;
                }
                MessageBox.Show("Seems like this book already exists. I am not gonna add it!");
                return;
            }
        }
        public bool CanAddNew(string bookName, string authorName, string bookDescription, DateTime bookDate)
        {
            if (String.IsNullOrEmpty(bookName) || String.IsNullOrEmpty(authorName) || String.IsNullOrEmpty(bookDescription))
            {
                return false;
            }
            return true;
        }
    }
}
