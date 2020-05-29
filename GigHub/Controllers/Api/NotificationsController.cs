using AutoMapper;
using GigHub.App_Start;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/notifications")]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            string userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.Notifications.GetNewNotifications(userId);

            var config = new MapperConfiguration(cfg =>
           {
               cfg.AddProfile<MappingProfile>();
           });

            IMapper mapper = config.CreateMapper();

            return notifications.Select(mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        [Route("api/notifications/read")]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.Notifications.GetUserNotifications(userId);

            notifications.ForEach(n => n.Read());

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
