using CarRental.Model;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            CarDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<CarDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.CarTypes.Any())
            {
                context.CarTypes.AddRange(
                    new CarType { CarTypeName = "VW" },
                    new CarType { CarTypeName = "BMW" },
                    new CarType { CarTypeName = "Toyota" },
                    new CarType { CarTypeName = "Nissan" },
                    new CarType { CarTypeName = "Mercedes-Benz" }
                 );
            }

            if (!context.Cars.Any())
            {
                context.Cars.AddRange
                 (
                    new Car
                    {
                        Name = "Golf 7 gti",
                        PricePerKM = 45M,
                        PickUpDate = DateTime.Parse("2023-04-30"),
                        ReturnDate = DateTime.Parse("2023-05-05"),
                        Description = "2.0-litre turbocharged direct-injection petrol engine (TSI) with 220 PS (162 kW; 217 hp). ",
                        ModelNo = 2021,
                        CarTypeId = 1
                    },
                 new Car
                 {
                     Name = "Scirocco",
                     PricePerKM = 35M,
                     PickUpDate = DateTime.Parse("2023-05-04"),
                     ReturnDate = DateTime.Parse("2023-05-09"),
                     Description = "The Scirocco GT24 is a race car for the 24-hour race at the Nürburgring. It has a 2.0 L TSI engine rated at 325 PS (239 kW; 321 hp). ",
                     ModelNo = 2022,
                     CarTypeId = 1
                 },
                 new Car
                 {
                     Name = "Tiguan",
                     PricePerKM = 50M,
                     PickUpDate = DateTime.Parse("2023-05-10"),
                     ReturnDate = DateTime.Parse("2023-05-13"),
                     Description = "Turbocharged four-cylinder that makes 184 horsepower; front-wheel drive is standard but Volkswagen's 4Motion all-wheel-drive system is optional. ",
                     ModelNo=2022,
                     CarTypeId = 1
                 },
                 new Car
                 {
                     Name = "BMW 3 Series",
                     PricePerKM = 38M,
                     PickUpDate = DateTime.Parse("2023-05-03"),
                     ReturnDate = DateTime.Parse("2023-05-06"),
                     Description = "Turbocharged 3.0-liter six-cylinder engine with 382 horsepower and 368 pound-feet of torque (M340i). ",
                     ModelNo=2021,
                     CarTypeId = 2
                 },
                  new Car
                  {
                      Name = "BMW Luxury class",
                      PricePerKM = 50M,
                      PickUpDate = DateTime.Parse("2023-05-02"),
                      ReturnDate = DateTime.Parse("2023-05-08"),
                      Description = "Includes 20-way power multi-contour front seats with articulated upper backrests, 4-way lumbar support, adjustable thigh support, and Active Head Restraints.",
                      ModelNo=2022,
                      CarTypeId = 2
                  },
                  new Car
                  {
                      Name = "Camry",
                      PricePerKM = 21M,
                      PickUpDate = DateTime.Parse("2023-05-02"),
                      ReturnDate = DateTime.Parse("2023-05-08"),
                      Description = "Camry offers a compelling choice of gasoline engines: a proficient 2.5-liter Dynamic Force 4-cylinder and a robust 3.5-liter V6.",
                      ModelNo = 2020,
                      CarTypeId = 3
                  },
                   new Car
                   {
                       Name = "Tundra",
                       PricePerKM = 23M,
                       PickUpDate = DateTime.Parse("2023-05-08"),
                       ReturnDate = DateTime.Parse("2023-05-10"),
                       Description = "Standard i-FORCE 3.5-liter Twin-Turbo V6 (389 HP / 479 LB-FT TQ) or available i-FORCE MAX 3.5-liter Twin-Turbo V6 hybrid.",
                       ModelNo = 2019,
                       CarTypeId = 3
                   },
                   new Car
                   {
                       Name = "Nissan Navara",
                       PricePerKM = 22M,
                       PickUpDate = DateTime.Parse("2023-04-22"),
                       ReturnDate = DateTime.Parse("2023-04-23"),
                       Description = "D23/Facelift Rubber Car Mats 3 Year Warranty",
                       ModelNo = 2019,
                       CarTypeId = 4
                   },
                   new Car
                   {
                       Name = "Nissan Qashqai",
                       PricePerKM = 18M,
                       PickUpDate = DateTime.Parse("2023-04-18"),
                       ReturnDate = DateTime.Parse("2023-04-18"),
                       Description = "5-door SUV. Layout. Front-engine, front-wheel-drive. Front-engine, four-wheel-drive.",
                       ModelNo = 2022,
                       CarTypeId = 4
                   },
                   new Car
                   {
                       Name = "A class - AMG",
                       PricePerKM = 10M,
                       PickUpDate = DateTime.Parse("2023-04-19"),
                       ReturnDate = DateTime.Parse("2023-04-19"),
                       Description = "hatchback or saloon.Two-tone sports seats and topstitching on instrument panel and beltline.",
                       ModelNo = 2022,
                       CarTypeId = 5
                   }
                 );
            }
            context.SaveChanges();
        }
    }
}
