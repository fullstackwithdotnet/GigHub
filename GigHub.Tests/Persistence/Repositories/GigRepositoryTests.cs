using FluentAssertions;
using GigHub.Core.Models;
using GigHub.Persistence;
using GigHub.Persistence.Repositories;
using GigHub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data.Entity;

namespace GigHub.Tests.Persistence.Repositories
{
    [TestClass]
    public class GigRepositoryTests
    {
        private GigsRepository _gigsRepository;
        private Mock<DbSet<Gig>> _mockGigs;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockGigs = new Mock<DbSet<Gig>>();
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.Setup(g => g.Gigs).Returns(_mockGigs.Object);

            _gigsRepository = new GigsRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetUpcomingGigsByArtist_GigIsInThePast_ShouldNotBeReturned()
        {
            var gig = new Gig() { DateTime = DateTime.Now.AddDays(-1), ArtistId = "1" };
            _mockGigs.SetSource(new[] { gig });

            var gigs = _gigsRepository.GetMyGigs("1");

            gigs.Should().BeEmpty();
        }

        [TestMethod]
        public void GetUpComingGigsByArtist_GigsAlreadyCancel_ShouldNotReturned()
        {
            var gig = new Gig() { DateTime = DateTime.Now.AddDays(1), ArtistId = "1" };
            gig.Cancel();

            _mockGigs.SetSource(new[] { gig });

            var gigs = _gigsRepository.GetMyGigs("1");

            gigs.Should().BeEmpty();
        }

        [TestMethod]
        public void GetUpcomingGigsByArtist_GigsForDifferentArtist_ShouldNotReturned()
        {
            var gig = new Gig() { DateTime = DateTime.Now.AddDays(1), ArtistId = "1" };

            _mockGigs.SetSource(new[] { gig });

            var gigs = _gigsRepository.GetMyGigs("2");

            gigs.Should().BeEmpty();
        }

        [TestMethod]
        public void GetUpcomingGigs_GigIsInFutureAndForTheGivenArtist_ShouldReturn()
        {
            var gig = new Gig() { DateTime = DateTime.Now.AddDays(1), ArtistId = "1" };


            _mockGigs.SetSource(new[] { gig });

            var gigs = _gigsRepository.GetMyGigs("1");

            gigs.Should().Contain(gig);

        }
    }
}
