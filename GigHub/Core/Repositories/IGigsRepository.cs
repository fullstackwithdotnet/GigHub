using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IGigsRepository
    {
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetMyGigs(string userId);
        Gig GetGig(int id);
        Attendance GetAttendance(int id, string userId);
        void Add(Gig gig);
        IEnumerable<Gig> GetUpcomingGigs();
    }
}