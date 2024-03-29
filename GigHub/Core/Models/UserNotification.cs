﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Core.Models
{
    public class UserNotification
    {

        [Key]
        [Column(Order = 1)]
        public int NotificationId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }

        public bool IsRead { get; private set; }

        [Required]
        public Notification Notification { get; private set; }
        [Required]
        public ApplicationUser User { get; private set; }

        protected UserNotification()
        {

        }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (notification == null)
                throw new ArgumentNullException("notification");

            User = user;
            Notification = notification;
        }

        public void Read()
        {
            IsRead = true;
        }
    }
}