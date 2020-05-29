using GigHub.Core;
using GigHub.Core.Repositories;
using GigHub.Persistence.Repositories;

namespace GigHub.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGigsRepository Gigs { get; private set; }
        public IAttendanceRepository Attendance { get; private set; }
        public IGenresRepository Genres { get; private set; }

        public INotificationsRepository Notifications { get; set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigsRepository(_context);
            Attendance = new AttendanceRepository(_context);
            Genres = new GenresRepository(_context);
            Notifications = new NotificationsRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}