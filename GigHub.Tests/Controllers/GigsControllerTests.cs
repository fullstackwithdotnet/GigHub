using GigHub.Controllers;
using GigHub.Core;
using GigHub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GigHub.Tests.Controllers
{
    [TestClass()]
    public class GigsControllerTests
    {
        private GigsController _controller;

        [TestInitialize]
        public void Setup()
        {
            var mUoW = new Mock<IUnitOfWork>();
            _controller = new GigsController(mUoW.Object);
            var userId = "1";

            _controller.MockCurrentUser(userId, "dumal@123.com");
        }

    }
}