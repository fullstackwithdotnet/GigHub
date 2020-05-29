using FluentAssertions;
using GigHub.Controllers.Api;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace GigHub.Tests.Controllers.Api
{
    [TestClass]
    public class AttendanceControllerTests
    {
        private Mock<IAttendanceRepository> _mockRepository;
        private AttendancesController _controller;
        private string _userId;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IAttendanceRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Attendance).Returns(_mockRepository.Object);

            _controller = new AttendancesController(mockUoW.Object);

            _userId = "1";
            _controller.MockCurrentUser(_userId, "user@domail.com");
        }

        [TestMethod]
        public void Attend_GigsAlreadyAttended_ShouldReturnBadRequest()
        {
            var attendance = new Attendance();

            _mockRepository.Setup(r => r.GetAttendance(_userId, 1)).Returns(attendance);

            var dto = new AttendanceDto
            {
                GigId = 1
            };

            var result = _controller.Attend(dto);

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void Attend_AttendingToGigCorrectly_ShouldReturnOk()
        {
            var dto = new AttendanceDto
            {
                GigId = 1
            };

            var result = _controller.Attend(dto);

            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public void NotAttending_NoAttendanceExists_ShouldReturnBadRequest()
        {
            //var attendance =  new Attendance();
            //_mockRepository.Setup(r => r.GetAttendance(_userId, 1)).Returns(attendance);

            var dto = new AttendanceDto
            {
                GigId = 1
            };
            _controller.NotGoing(dto).Should().BeOfType<NotFoundResult>();

        }

        [TestMethod]
        public void NotGoing_AttendanceExists_ShouldReturnOk()
        {
            var attendance = new Attendance();
            _mockRepository.Setup(r => r.GetAttendance(_userId, 1)).Returns(attendance);

            var dto = new AttendanceDto
            {
                GigId = 1
            };

            _controller.NotGoing(dto).Should().BeOfType<OkNegotiatedContentResult<int>>();
        }
    }
}
