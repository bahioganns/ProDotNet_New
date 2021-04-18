using Domain;
using Domain.Models;
using BusinessLogic.Contracts;
using BusinessLogic.Implementations;
using DataAccess.Contracts;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Test
{
    public class BookServiceTests
    {
        private Mock<IBookDataAccess> fakeBookDataAccess;
        private Book expected;

        [SetUp]
        public void SetUp()
        {
            fakeBookDataAccess = new Mock<IBookDataAccess>();
            expected = new Book { Id = 1, Name = "Name"};
        }

        [Test]
        public void TestCreateBook()
        {
            // Arrange
            fakeBookDataAccess.Setup(x => x.Insert(It.IsAny<BookUpdateModel>())).Returns(expected);

            // Action
            var bookService = new BookService(fakeBookDataAccess.Object);
            Book book = bookService.CreateBook(new BookUpdateModel());

            // Assert
            Assert.AreEqual(book.Id, expected.Id);
            Assert.AreEqual(book.Name, expected.Name);
        }

        [Test]
        public void TestGetBook()
        {
            // Arrange
            fakeBookDataAccess.Setup(x => x.Get(It.IsAny<BookIdentityModel>())).Returns(expected);

            // Action
            var bookService = new BookService(fakeBookDataAccess.Object);
            Book book = bookService.GetBook(new BookIdentityModel(1));

            // Assert
            Assert.AreEqual(book.Id, expected.Id);
            Assert.AreEqual(book.Name, expected.Name);

        }

        [Test]
        public void TestUpdateBook()
        {
            // Arrange
            fakeBookDataAccess.Setup(x => x.Update(It.IsAny<BookIdentityModel>(), It.IsAny<BookUpdateModel>())).Returns(expected);

            // Action
            var bookService = new BookService(fakeBookDataAccess.Object);
            Book book = bookService.UpdateBook(new BookIdentityModel(1), new BookUpdateModel());

            // Assert
            Assert.AreEqual(book.Id, expected.Id);
            Assert.AreEqual(book.Name, expected.Name);
        }

        [Test]
        public void TestDeleteBook()
        {
            // Arrange
            fakeBookDataAccess.Setup(x => x.Delete(It.IsAny<BookIdentityModel>()));

            // Action
            var bookService = new BookService(fakeBookDataAccess.Object);
            bookService.DeleteBook(new BookIdentityModel(1));

            // Assert
            fakeBookDataAccess.Verify(x => x.Delete(It.IsAny<BookIdentityModel>()), Times.Once());
        }
    }
}
