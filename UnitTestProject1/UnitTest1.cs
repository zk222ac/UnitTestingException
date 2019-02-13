using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingException;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        private Book _book;
        private const string ToShortCharacter = "Character must not be less than 2";
        //private const string ToShortCharacter = "Character must not be less than 2";

        [TestInitialize]
        public void InitializeTest()
        {
            // Arrange Test...................
            _book = new Book("Book", 2019, "zk222ac@gmail.com");
        }
        [TestMethod]
        public void LegalTest()
        {
            Assert.AreEqual("Book", _book.Title);
            Assert.AreEqual(2019, _book.Year);
            Assert.AreEqual("zk222ac@gmail.com", _book.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), nameof(ToShortCharacter))]
        public void CheckTitleTest()
        {
            CheckTitleEmptyTest();
            CheckTitleNullTest();
            CheckTitleToShortTest();
        }
        [ExpectedException(typeof(ArgumentException), nameof(ToShortCharacter))]
        public void CheckTitleEmptyTest()
        {
            _book.Title = "";
            Assert.AreEqual("", _book.Title);
        }
        [ExpectedException(typeof(ArgumentException), nameof(ToShortCharacter))]

        public void CheckTitleNullTest()
        {
            _book.Title = null;
            Assert.AreEqual(null, _book.Title);
        }
        [ExpectedException(typeof(ArgumentException), nameof(ToShortCharacter))]
        public void CheckTitleToShortTest()
        {
            // Logic check against minimum 2 characters
            _book.Title = "t";
            Assert.Fail("t", _book.Title);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckYearTest()
        {
            // Limit Value Test :
            // The limits are 1100 and 2019 which is why we testing for 
            // Limit under 1099 and over 2020 throw en exception 

            // legal limit values........................
            _book.Year = 1100;
            _book.Year = 2019;
            _book.Year = 2000;

            // Illegal limit values 
            _book.Year = 1099;
            _book.Year = 2020;

            Invalid1099();
            Invalid2020();
        }
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Invalid1099()
        {
            _book.Year = 1099;
            Assert.Fail();
        }
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Invalid2020()
        {
            _book.Year = 2020;
            Assert.Fail();
        }

    }
}
