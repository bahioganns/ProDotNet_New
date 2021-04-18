using Domain;
using Domain.Models;
using BusinessLogic.Implementations;
using DataAccess.Contracts;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;


namespace BusinessLogic.Test
{
    public class VisitorServiceTests
    {
        private Mock<IVisitorDataAccess> fakeVisitorDataAccess;
        private Visitor expected;

        [SetUp]
        public void SetUp()
        {
            fakeVisitorDataAccess = new Mock<IVisitorDataAccess>();
            expected = new Visitor { Id = 1, Login = "1A456"};
        }

        [Test]
        public void TestCreateVisitor()
        {
            fakeVisitorDataAccess.Setup(x => x.Insert(It.IsAny<VisitorUpdateModel>())).Returns(expected);

            var visitorService = new VisitorService(fakeVisitorDataAccess.Object);
            Visitor visitor = visitorService.CreateVisitor(new VisitorUpdateModel());

            Assert.AreEqual(visitor.Id, expected.Id);
            Assert.AreEqual(visitor.Login, expected.Login);

        }

        [Test]
        public void TestGetVisitor()
        {
            fakeVisitorDataAccess.Setup(x => x.Get(It.IsAny<VisitorIdentityModel>())).Returns(expected);

            var visitorService = new VisitorService(fakeVisitorDataAccess.Object);
            Visitor visitor = visitorService.GetVisitor(new VisitorIdentityModel(1));

            Assert.AreEqual(visitor.Id, expected.Id);
            Assert.AreEqual(visitor.Login, expected.Login);
        }

        [Test]
        public void TestUpdateVisitor()
        {
            fakeVisitorDataAccess.Setup(x => x.Update(It.IsAny<VisitorIdentityModel>(), It.IsAny<VisitorUpdateModel>())).Returns(expected);

            var visitorService = new VisitorService(fakeVisitorDataAccess.Object);
            Visitor visitor = visitorService.UpdateVisitor(new VisitorIdentityModel(1), new VisitorUpdateModel());

            Assert.AreEqual(visitor.Id, expected.Id);
            Assert.AreEqual(visitor.Login, expected.Login);
        }

        [Test]
        public void TestDeleteVisitor()
        {
            fakeVisitorDataAccess.Setup(x => x.Delete(It.IsAny<VisitorIdentityModel>()));

            var visitorService = new VisitorService(fakeVisitorDataAccess.Object);
            visitorService.DeleteVisitor(new VisitorIdentityModel(1));

            fakeVisitorDataAccess.Verify(x => x.Delete(It.IsAny<VisitorIdentityModel>()), Times.Once());
        }

        [Test]
        public void TestSuccessfullValidateVisitor()
        {
            List<VisitorUpdateModel> goodVisitorUpdateModels = new List<VisitorUpdateModel>();
            goodVisitorUpdateModels.Add(new VisitorUpdateModel { Login = "7435"});
            goodVisitorUpdateModels.Add(new VisitorUpdateModel { Login = "1254"});
            goodVisitorUpdateModels.Add(new VisitorUpdateModel { Login = "45123"});
            goodVisitorUpdateModels.Add(new VisitorUpdateModel { Login = "1"});

            var visitorService = new VisitorService(fakeVisitorDataAccess.Object);

            goodVisitorUpdateModels.ForEach((visitor) => {
                Assert.DoesNotThrow(() => visitorService.ValidateVisitor(visitor));
            });
        }

        [Test]
        public void TestFaildeValidateVisitor()
        {
            List<VisitorUpdateModel> badVisitorUpdateModels = new List<VisitorUpdateModel>();
            badVisitorUpdateModels.Add(new VisitorUpdateModel { Login = "12345A"});
            badVisitorUpdateModels.Add(new VisitorUpdateModel { Login = "123Z"});
            badVisitorUpdateModels.Add(new VisitorUpdateModel { Login = "AAA"});
            badVisitorUpdateModels.Add(new VisitorUpdateModel { Login = "1A234"});

            var visitorService = new VisitorService(fakeVisitorDataAccess.Object);

            badVisitorUpdateModels.ForEach((visitor) => {
                Assert.Catch<ArgumentException>(() => visitorService.ValidateVisitor(visitor));
            });
        }
    }
}