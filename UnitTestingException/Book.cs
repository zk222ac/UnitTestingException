using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTestingException
{
    public class Book
    {
        private const string YearRange = "Year must be between 1100 and 2019";
        private const string TwoCharLong = "Title must be 2 character long";
        private string _title;
        private int _year;
        private string _email;


        public string Title
        {
            get => _title;
            set
            {
                CheckTitle(value);
                _title = value;
            }
        }
        public int Year
        {
            get => _year;
            set
            {
                CheckYear(value);
                _year = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                CheckEmail(value);
                _email = value;
            }
        }

        public Book(string title, int year, string email)
        {
            CheckTitle(title);
            CheckYear(year);
            CheckEmail(email);
            _title = title;
            _year = year;
            _email = email;
        }

        public Book()
        {

        }

        // Throw exception if value not fulfill the requirement  
        public void CheckTitle(string title)
        {
            if (title != null && (!string.IsNullOrEmpty(title) && (title.Length < 2)))
            {
                throw new ArgumentException(TwoCharLong);
            }
        }
        public void CheckYear(int year)
        {
            if ((year < 1100) || (year > 2019))
            {
                throw new ArgumentOutOfRangeException(YearRange);
            }
        }

        public void CheckEmail(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.IsMatch(email))
            {
                throw new InvalidEmailException(email);
            }
        }
    }
}
