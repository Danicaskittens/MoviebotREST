namespace api.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using api.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<api.Models.ReservationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(api.Models.ReservationContext context)
        {
          
            context.Reservations.AddOrUpdate(
              r => r.Id,
              new Reservation()
              {
                  Id = 1,
                  Quantity = 2,
                  Price = 7.5m,
                  Status = "Pending",
                  TimeStamp = "20161023",
                  ProjectionId = 101,
                  UserId = 123
              },
              new Reservation()
              {
                  Id = 2,
                  Quantity = 3,
                  Price = 7.5m,
                  Status = "Pending",
                  TimeStamp = "20161010",
                  ProjectionId = 102,
                  UserId = 456
              } 
              );

            context.Projections.AddOrUpdate(x => x.Id,
                new Projection()
                {
                    Id = 101,
                    MovieId = 999,
                    CinemaId = 234,
                    Slot = 3,
                    Date = "20161024"
                },
                new Projection()
                {
                    Id = 102,
                    MovieId = 888,
                    CinemaId = 234,
                    Slot = 2,
                    Date = "20161011"
                }
                );
            
        }
    }
}
