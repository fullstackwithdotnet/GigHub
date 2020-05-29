using GigHub.Core.Repositories;

namespace GigHub.Core
{
    public interface IUnitOfWork
    {
        IGigsRepository Gigs { get; }
        IAttendanceRepository Attendance { get; }
        IGenresRepository Genres { get; }
        INotificationsRepository Notifications { get; }
        void Complete();
    }
}