using GigHub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub.Persistence.EntityConfigurations
{
    public class UserNotificationConfiguration : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration()
        {
            Property(un => un.NotificationId)
                .HasColumnOrder(1);

            Property(un => un.UserId)
                .HasColumnOrder(2);


        }
    }
}