using Bogus;
using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.Entities;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Api.Extensions
{
    public static class DatabaseSeeder
    {
        private static readonly Faker _faker = new Faker();
        public static void SeedData(this IServiceCollection _,IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<StaySphereDbContext>>();
            using var context= new StaySphereDbContext(options);

            CreatEmployees(context);
            CreatDocuments(context);
            CreatCategories(context);
            CreatRooms(context);
            CreatGuests(context);
            CreatBookings(context);
            CreatReviews(context);
            CreatPositions(context);
        }
        private static void CreatEmployees(StaySphereDbContext context)
        {
            if (context.Employees.Any()) return;

            var positions = new List<Position>
            {
                new Position { Name = "Manager", Salary = 5000 },
                new Position { Name = "Receptionist", Salary = 3000 },
                new Position { Name = "Housekeeper", Salary = 2500 },
                new Position { Name = "Chef", Salary = 4000 },
                new Position { Name = "Concierge", Salary = 3500 },
                new Position { Name = "Front Desk Supervisor", Salary = 3500 },
                new Position { Name = "Bellboy", Salary = 2000 },
                new Position { Name = "Room Service Attendant", Salary = 3000 },
                new Position { Name = "Event Coordinator", Salary = 4000 },
                new Position { Name = "Security Officer", Salary = 3200 },
                new Position { Name = "Valet Parking Attendant", Salary = 2500 },
                new Position { Name = "Spa Therapist", Salary = 3500 },
                new Position { Name = "Hotel Accountant", Salary = 4500 },
                new Position { Name = "Maintenance Technician", Salary = 3200 },
                new Position { Name = "Human Resources Coordinator", Salary = 3800 },
                new Position { Name = "Marketing Specialist", Salary = 4000 },
                new Position { Name = "Guest Relations Manager", Salary = 4800 },
                new Position { Name = "Barista", Salary = 2300 },
                new Position { Name = "Lifeguard", Salary = 2700 }
            };

            context.Positions.AddRange(positions);
            context.SaveChanges();

            var employees = new List<Employee>();
            foreach (var position in positions)
            {
                for (int i = 0; i < 5; i++)
                {
                    employees.Add(new Employee
                    {
                        FirstName = _faker.Name.FirstName(),
                        LastName = _faker.Name.LastName(),
                        PhoneNumber = _faker.Phone.PhoneNumber(),
                        Salary = position.Salary,
                        PositionId = position.Id
                    });
                }
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }

        private static void CreatDocuments(StaySphereDbContext context)
        {
            if (context.Documents.Any()) return;

            var documents = new List<Domain.Entities.Document>();
            for (int i = 0; i < 20; i++)
            {
                documents.Add(new Domain.Entities.Document
                {
                    SerialNumber = _faker.Random.Number(100000, 999999),
                    FirstName = _faker.Name.FirstName(),
                    LastName = _faker.Name.LastName(),
                    BirthDate = _faker.Date.Past(30),
                    Gender = _faker.PickRandom("Male", "Female")
                });
            }

            context.Documents.AddRange(documents);
            context.SaveChanges();
        }

        public static void CreatCategories(StaySphereDbContext context)
        {
            if (context.Categories.Any()) return;

            var categories = new List<Category>();
            for (int i = 0; i < 10; i++)
            {
                categories.Add(new Category
                {
                    Name = _faker.Commerce.Department(),
                    Price = _faker.Random.Decimal(50, 500)
                });
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        public static void CreatRooms(StaySphereDbContext context)
        {
            if (context.Rooms.Any()) return;

            var categories = context.Categories.ToList();
            var rooms = new List<Room>();
            for (int i = 0; i < 20; i++)
            {
                rooms.Add(new Room
                {
                    Number = _faker.Random.Number(100, 999),
                    Floor = _faker.Random.Number(1, 10),
                    CategoryId = _faker.PickRandom(categories).Id
                });
            }

            context.Rooms.AddRange(rooms);
            context.SaveChanges();
        }

        public static void CreatGuests(StaySphereDbContext context)
        {
            if (context.Guests.Any()) return;

            var documents = context.Documents.ToList();
            var guests = new List<Guest>();
            for (int i = 0; i < 50; i++)
            {
                guests.Add(new Guest
                {
                    PhoneNumber = _faker.Phone.PhoneNumber(),
                    Email = _faker.Internet.Email(),
                    DocumentId = _faker.PickRandom(documents).Id
                });
            }

            context.Guests.AddRange(guests);
            context.SaveChanges();
        }

        public static void CreatBookings(StaySphereDbContext context)
        {
            if (context.Bookings.Any()) return;

            var guests = context.Guests.ToList();
            var employees = context.Employees.ToList();
            var rooms = context.Rooms.ToList();
            var bookings = new List<Booking>();
            for (int i = 0; i < 100; i++)
            {
                bookings.Add(new Booking
                {
                    CheckInDate = _faker.Date.Between(DateTime.Now, DateTime.Now.AddDays(30)),
                    CheckOutDate = _faker.Date.Between(DateTime.Now.AddDays(31), DateTime.Now.AddDays(60)),
                    TotalPrice = _faker.Random.Decimal(100, 2000),
                    GuestId = _faker.PickRandom(guests).Id,
                    EmployeeId = _faker.PickRandom(employees).Id,
                    RoomId = _faker.PickRandom(rooms).Id
                });
            }

            context.Bookings.AddRange(bookings);
            context.SaveChanges();
        }

        public static void CreatReviews(StaySphereDbContext context)
        {
            if (context.Reviews.Any()) return;

            var bookings = context.Bookings.ToList();
            var reviews = new List<Review>();
            for (int i = 0; i < 50; i++)
            {
                reviews.Add(new Review
                {
                    Comment = _faker.Random.Words(),
                    Grade = _faker.Random.Decimal(1, 5),
                    BookingId = _faker.PickRandom(bookings).Id
                });
            }

            context.Reviews.AddRange(reviews);
            context.SaveChanges();
        }

        public static void CreatPositions(StaySphereDbContext context)
        {
            if (context.Positions.Any()) return;

            var positions = new List<Position>
            {
                new Position { Name = "Manager", Salary = 5000 },
                new Position { Name = "Receptionist", Salary = 3000 },
                new Position { Name = "Housekeeper", Salary = 2500 },
                new Position { Name = "Chef", Salary = 4000 },
                new Position { Name = "Concierge", Salary = 3500 },
                new Position { Name = "Front Desk Supervisor", Salary = 3500 },
                new Position { Name = "Bellboy", Salary = 2000 },
                new Position { Name = "Room Service Attendant", Salary = 3000 },
                new Position { Name = "Event Coordinator", Salary = 4000 },
                new Position { Name = "Security Officer", Salary = 3200 },
                new Position { Name = "Valet Parking Attendant", Salary = 2500 },
                new Position { Name = "Spa Therapist", Salary = 3500 },
                new Position { Name = "Hotel Accountant", Salary = 4500 },
                new Position { Name = "Maintenance Technician", Salary = 3200 },
                new Position { Name = "Human Resources Coordinator", Salary = 3800 },
                new Position { Name = "Marketing Specialist", Salary = 4000 },
                new Position { Name = "Guest Relations Manager", Salary = 4800 },
                new Position { Name = "Barista", Salary = 2300 },
                new Position { Name = "Lifeguard", Salary = 2700 }
            };

            context.Positions.AddRange(positions);
            context.SaveChanges();
        }
    }
}