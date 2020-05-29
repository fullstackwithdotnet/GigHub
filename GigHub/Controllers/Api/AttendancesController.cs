using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/attendances")]
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Attendance.GetAttendance(userId, attendanceDto.GigId) != null)
            {
                return BadRequest("The attendance already exists.");
            }

            var attendance = new Attendance
            {
                GigId = attendanceDto.GigId,
                AttendeeId = userId
            };

            _unitOfWork.Attendance.Add(attendance);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult NotGoing(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _unitOfWork.Attendance.GetAttendance(userId, attendanceDto.GigId);

            if (attendance == null)
                return NotFound();


            _unitOfWork.Attendance.Remove(attendance);
            _unitOfWork.Complete();

            return Ok(attendanceDto.GigId);
        }
    }
}
