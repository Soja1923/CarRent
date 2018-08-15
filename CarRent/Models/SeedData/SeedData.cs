using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CarRent.Data;
using Microsoft.Extensions.DependencyInjection;
using CarRent.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.IO;

namespace CarRent.Models.SeedData
{
    public class SeedData
    {
        public static void Ensure(IApplicationBuilder app)
        {
            ApplicationDbContext dbContext = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();

            var grades = new List<Grade>
            {
                new Grade { GradeType = GradeType.A, PricePerDay = 49.00 },
                new Grade { GradeType = GradeType.B, PricePerDay = 69.00 },
                new Grade { GradeType = GradeType.C, PricePerDay = 99.00 },
                new Grade { GradeType = GradeType.D, PricePerDay = 129.00 },
                new Grade { GradeType = GradeType.Premium, PricePerDay = 239.00 },
                new Grade { GradeType = GradeType.SUV, PricePerDay = 99.00 },
                new Grade { GradeType = GradeType.BUS, PricePerDay = 99.00 }
            };

            if (!dbContext.GetGrades.Any())
            {
                dbContext.GetGrades.AddRange(grades);
                dbContext.SaveChanges();
            }

            var addresses = new List<Address>
            {
                new Address { City = "Warszawa", Street = "Daleka", Number = "23B", PostalCode = "44-555" },
                new Address { City = "Kraków", Street = "Polna", Number = "190", PostalCode = "33-444" },
                new Address { City = "Warszawa", Street = "Szpitalna", Number = "12", PostalCode = "44-555" },
                new Address { City = "Katowice", Street = "Leśna", Number = "120", PostalCode = "11-020" },
                new Address { City = "Szczecin", Street = "Malinowa", Number = "87", PostalCode = "99-999" },
                new Address { City = "Lublin", Street = "Sosnowa", Number = "1", PostalCode = "91-187" },
                //od 6 do 17
                new Address { City = "Warszawa", Street = "Leśna", Number = "53B", PostalCode = "44-555" },
                new Address { City = "Warszawa", Street = "Polna", Number = "9", PostalCode = "44-555" },

                new Address { City = "Warszawa", Street = "Miodowa", Number = "12", PostalCode = "44-555" },

                new Address { City = "Katowice", Street = "Górna", Number = "67", PostalCode = "11-020" },
                new Address { City = "Katowice", Street = "Kasztanowa", Number = "7", PostalCode = "11-020" },

                new Address { City = "Kraków", Street = "Rzeczna", Number = "31", PostalCode = "33-444" },
                new Address { City = "Kraków", Street = "Daleka", Number = "23/12", PostalCode = "33-444" },
                new Address { City = "Kraków", Street = "Dolna", Number = "1", PostalCode = "33-444" },

                new Address { City = "Szczecin", Street = "Słoneczna", Number = "2", PostalCode = "99-999" },
                new Address { City = "Szczecin", Street = "Złota", Number = "58/17", PostalCode = "99-999" },

                new Address { City = "Lublin", Street = "Tymiankowa", Number = "71", PostalCode = "91-187" },
                new Address { City = "Lublin", Street = "Grzybowa", Number = "16", PostalCode = "91-187" },

                //od 18 do 30
                new Address { City = "Warszawa", Street = "Akacjowa", Number = "10", PostalCode = "44-555" },
                new Address { City = "Warszawa", Street = "Akademicka", Number = "21", PostalCode = "44-555" },
                new Address { City = "Warszawa", Street = "Al. Niepodległości", Number = "321", PostalCode = "44-555" },

                new Address { City = "Katowice", Street = "Biała", Number = "99", PostalCode = "11-020" },
                new Address { City = "Katowice", Street = "Cedrowa", Number = "77", PostalCode = "11-020" },

                new Address { City = "Kraków", Street = "Ciepła", Number = "33", PostalCode = "33-444" },
                new Address { City = "Kraków", Street = "Daktylowa", Number = "44A", PostalCode = "33-444" },
                new Address { City = "Kraków", Street = "Dobra", Number = "3", PostalCode = "33-444" },

                new Address { City = "Szczecin", Street = "Fabryczna", Number = "82", PostalCode = "99-999" },
                new Address { City = "Szczecin", Street = "Falowa", Number = "57", PostalCode = "99-999" },

                new Address { City = "Lublin", Street = "Gołębia", Number = "21", PostalCode = "91-187" },
                new Address { City = "Lublin", Street = "Jaskółcza", Number = "6", PostalCode = "91-187" }
            };
            
            if (!dbContext.GetAddresses.Any())
            { 
                dbContext.GetAddresses.AddRange(addresses);
                dbContext.SaveChanges();
            }

            var locations = new List<Location>()
            {
                new Location { Address = addresses[0], E_mail="carrentWarszawa@gmail.com", Phone_Number="111-222-333",  },
                new Location { Address = addresses[1], E_mail = "carrentKraków@gmail.com", Phone_Number = "222-333-444" },
                new Location { Address = addresses[2], E_mail = "carrentWarszawa2@gmail.com", Phone_Number = "333-444-555" },
                new Location { Address = addresses[3], E_mail = "carrentKatowice@gmail.com", Phone_Number = "555-666-777" },
                new Location { Address = addresses[4], E_mail = "carrentSzczecin@gmail.com", Phone_Number = "666-777-888" },
                new Location { Address = addresses[5], E_mail = "carrentLublin@gmial.com", Phone_Number = "777-888-999" }
            };
               
            if (!dbContext.GetLocations.Any())
            {
                dbContext.GetLocations.AddRange(locations);
                dbContext.SaveChanges();
            }

            var users = new List<ApplicationUser>
            {
                new ApplicationUser { Email = "pracownik01_Warszawa@gmail.com", PhoneNumber = "011-111-111" },
                new ApplicationUser { Email = "pracownik02_Warszawa@gmail.com", PhoneNumber = "022-222-222" },
                new ApplicationUser { Email = "pracownik03_Warszawa@gmail.com", PhoneNumber = "044-444-444" },
                new ApplicationUser { Email = "pracownik04_Katowice@gmail.com", PhoneNumber = "033-333-333" },
                new ApplicationUser { Email = "pracownik05_Katowice@gmial.com", PhoneNumber = "055-555-555" },
                new ApplicationUser { Email = "pracownik06_Kraków@gmail.com", PhoneNumber = "066-666-666" },
                new ApplicationUser { Email = "pracownik07_Kraków@gmail.com", PhoneNumber = "077-777-777" },
                new ApplicationUser { Email = "pracownik08_Kraków@gmail.com", PhoneNumber = "088-888-888" },
                new ApplicationUser { Email = "pracownik09_Szczecin@gmail.com", PhoneNumber = "099-999-999" },
                new ApplicationUser { Email = "pracownik10_Szczecin@gmail.com", PhoneNumber = "012-112-112" },
                new ApplicationUser { Email = "pracownik11_Lublin@gmail.com", PhoneNumber = "013-113-113" },
                new ApplicationUser { Email = "pracownik12_Lublin@gmail.com", PhoneNumber = "014-114-114" },

                new ApplicationUser { Email = "klient01@gmail.com", PhoneNumber = "111-121-111" },
                new ApplicationUser { Email = "klient02@gmail.com", PhoneNumber = "122-232-222" },
                new ApplicationUser { Email = "klient03@gmail.com", PhoneNumber = "144-424-444" },
                new ApplicationUser { Email = "klient04@gmail.com", PhoneNumber = "133-323-333" },
                new ApplicationUser { Email = "klient05@gmial.com", PhoneNumber = "155-525-555" },
                new ApplicationUser { Email = "klient06@gmail.com", PhoneNumber = "166-626-666" },
                new ApplicationUser { Email = "klient07gmail.com", PhoneNumber = "177-727-777" },
                new ApplicationUser { Email = "klient08@gmail.com", PhoneNumber = "188-828-888" },
                new ApplicationUser { Email = "klient09@gmail.com", PhoneNumber = "199-929-999" },
                new ApplicationUser { Email = "klient10@gmail.com", PhoneNumber = "112-122-112" },
                new ApplicationUser { Email = "klient11@gmail.com", PhoneNumber = "113-123-113" },
                new ApplicationUser { Email = "klient12@gmail.com", PhoneNumber = "114-124-114" },



            };
            if (!dbContext.GetUsers.Any())
            {
                dbContext.AddRange(users);
                dbContext.SaveChanges();
            }

            var employees = new List<Employee>
            {
                new Employee { Name = "Jakub", LastName = "Kamiński", PESEL = "33092210699", Location = locations[0], Address = addresses[6] ,ApplicationUser=users[0] },
                new Employee { Name = "Sebastian", LastName = "Urbański", PESEL = "36091630039", Location = locations[0], Address = addresses[7] , ApplicationUser = users[1] },
                new Employee { Name = "Luiza", LastName = "Kozłowska", PESEL = "65111811903", Location = locations[2], Address = addresses[8], ApplicationUser = users[2] },
                new Employee { Name = "Kacper", LastName = "Bukowski", PESEL = "65010241939", Location = locations[3], Address = addresses[9], ApplicationUser = users[3] },
                new Employee { Name = "Ewa", LastName = "Sikora", PESEL = "75072351109", Location = locations[3], Address = addresses[10], ApplicationUser = users[4] },
                new Employee { Name = "Wiktoria", LastName = "Mazur", PESEL = "98120858148", Location = locations[1], Address = addresses[11], ApplicationUser = users[5] },
                new Employee { Name = "Mateusz", LastName = "Wróbel", PESEL = "15060102597", Location = locations[1], Address = addresses[12], ApplicationUser = users[6] },
                new Employee { Name = "Jakub", LastName = "Dąbrowski", PESEL = "44093004691", Location = locations[1], Address = addresses[13], ApplicationUser = users[7] },
                new Employee { Name = "Maciej", LastName = "Sowa", PESEL = "17121935153", Location = locations[4], Address = addresses[14], ApplicationUser = users[8] },
                new Employee { Name = "Krzysztof", LastName = "Piotrowski", PESEL = "41110410299", Location = locations[4], Address = addresses[15], ApplicationUser = users[9] },
                new Employee { Name = "Bartek", LastName = "Jabłoński", PESEL = "13270861619", Location = locations[5], Address = addresses[16], ApplicationUser = users[10] },
                new Employee { Name = "Mikołaj", LastName = "Kołodziejczyk", PESEL = "39020575294", Location = locations[5], Address = addresses[17], ApplicationUser = users[11] }
            };
            var customers = new List<Customer>
            {
                new Customer{Name="Wojciech", LastName="Zięba", PESEL="30022175437", Address=addresses[18], ApplicationUser=users[12]},
                new Customer{Name="Mateusz", LastName="Urbaniak", PESEL="94112117398", Address=addresses[19], ApplicationUser=users[13]},
                new Customer{Name="Natalia", LastName="Borkowska", PESEL="09121697447", Address=addresses[20], ApplicationUser=users[14]},
                new Customer{Name="Wiktor", LastName="Michalski", PESEL="02072082753", Address=addresses[21], ApplicationUser=users[15]},
                new Customer{Name="Martyna", LastName="Szymańska", PESEL="16022852622", Address=addresses[22], ApplicationUser=users[16]},
                new Customer{Name="Alan", LastName="Borowski", PESEL="69123102756", Address=addresses[23], ApplicationUser=users[17]},
                new Customer{Name="Sara", LastName="Brzezińska", PESEL="65092410267", Address=addresses[24], ApplicationUser=users[18]},
                new Customer{Name="Karolina", LastName="Kowalczyk", PESEL="14112654642", Address=addresses[25], ApplicationUser=users[19]},
                new Customer{Name="Kacper", LastName="Karpiński", PESEL="81102009290", Address=addresses[26], ApplicationUser=users[20]},
                new Customer{Name="Mikołaj", LastName="Kacprzak", PESEL="60060561035", Address=addresses[27], ApplicationUser=users[21]},
                new Customer{Name="Mateusz", LastName="Nowak", PESEL="28062036775", Address=addresses[28], ApplicationUser=users[22]},
                new Customer{Name="Anna", LastName="Domagała", PESEL="62061687280", Address=addresses[29], ApplicationUser=users[23]}
            };
             if(!dbContext.GetPeople.Any())
            {
                dbContext.GetPeople.AddRange(employees);
                dbContext.GetPeople.AddRange(customers);
                dbContext.SaveChanges();
            }
            string directoryName = Directory.GetCurrentDirectory(); 
            var cars = new List<Car>()
            {

            new Car
            {
                Mark = "Fiat",
                Model = "500",
                Fuel = FuelType.Benzyna,
                Description = "Samochód osobowy klasy aut miejskich produkowany przez włoski koncern motoryzacyjny Fiat od maja 2007. " +
               "Auto stylistyką oraz oznaczeniem modelu nawiązuje do produkowanego w latach 1957–1975 modelu 500.",
                GearboxType = Gearbox.Manual,
                NumberOfSeats = 4,
                EngineCapacity = 1242.00,
                Body = BodyType.Hatchback,
                Grade = grades[0],
                Year = 2014,
                Img = ImgConverter.ImgToByte(directoryName + "\\wwwroot\\img\\tmp\\car_2.jpg")
            },
            new Car
            {
                Mark = "Toyota",
                Model = "Auris",
                Fuel = FuelType.Benzyna,
                Description = "Toyota Auris - samochód osobowy klasy kompaktowej produkowany przez japoński koncern motoryzacyjny Toyota Motor Corporation od 2006 roku. Od 2019 roku produkowana będzie trzecia generacja pojazdu.",
                GearboxType = Gearbox.Manual,
                NumberOfSeats = 4,
                EngineCapacity = 1329.00,
                Body = BodyType.Hatchback,
                Grade = grades[2],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_3.png")
            },
            new Car
            {
                Mark = "Chevrolet",
                Model = "Aveo",
                Fuel = FuelType.Benzyna,
                Description = "Chevrolet Aveo – samochód osobowy produkowany od 2002 roku przez koncern GM Daewoo, a później Chevrolet. " +
                     "Obecnie produkowana jest druga generacja modelu, oznaczona symbolem T300.",
                GearboxType = Gearbox.Manual,
                NumberOfSeats = 4,
                EngineCapacity = 1229.00,
                Body = BodyType.Hatchback,
                Grade = grades[1],
                Year = 2014,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_4.jpg")
            },
            new Car
            {
                Mark = "Toyota",
                Model = "Aygo",
                Fuel = FuelType.Benzyna,
                Description = "Toyota Aygo – samochód osobowy klasy aut miejskich produkowany od 2005 roku. Samochód został opracowany we współpracy z koncernem PSA w wyniku której powstały trzy bliźniacze modele: Toyota Aygo, Citroen C1 oraz Peugeot 107. Od 2014 roku produkowana jest druga generacja modelu.",
                GearboxType = Gearbox.Manual,
                NumberOfSeats = 5,
                EngineCapacity = 98.00,
                Body = BodyType.Hatchback,
                Grade = grades[0],
                Year = 2014,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_5.jpg")
            },
            new Car
            {
                Mark = "Toyota",
                Model = "Auris",
                Fuel = FuelType.Benzyna,
                Description = "Toyota Auris to samochód osobowy produkowany przez japoński koncern motoryzacyjny Toyota Motor Corporation od października 2006 roku.Auris na większości rynków zastąpił Toyotę Corollę w wersji hatchback.Na pozostałych rynkach – Corollę RunX, a tylko w Australii oferowany jest pod nazwą Corolla.",
                GearboxType = Gearbox.Manual,
                NumberOfSeats = 5,
                EngineCapacity = 998.00,
                Body = BodyType.Hatchback,
                Grade = grades[0],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_6.png")
            },
            new Car
            {
                Mark = "Ford",
                Model = "Focus ",
                Fuel = FuelType.Benzyna,
                Description = "Ford Focus – samochód osobowy klasy kompaktowej produkowany przez amerykański koncern motoryzacyjny Ford Motor Company od 1998 roku jako następca Escorta. Od 2018 roku produkowana jest czwarta generacja.",
                GearboxType = Gearbox.Manual,
                NumberOfSeats = 5,
                EngineCapacity = 1560.00,
                Body = BodyType.Kombi,
                Grade = grades[2],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_7.jpg")
            },
            new Car
            {
                Mark = "Kia",
                Model = "Sportage",
                Fuel = FuelType.Diesel,
                Description = "Kia Sportage - osobowy segmentu kompaktowych SUV-ów produkowany przez południowokoreański koncern motoryzacyjny Kia Motors od lipca 1993 roku. Od 2016 roku produkowana jest czwarta generacja pojazdu.",
                GearboxType = Gearbox.Automat,
                NumberOfSeats = 5,
                EngineCapacity = 1696.00,
                Body = BodyType.Kombi,
                Grade = grades[5],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_1.png")
            },
            new Car
            {
                Mark = "Ford",
                Model = "Transit",
                Fuel = FuelType.Diesel,
                Description = "Ford Transit − samochód dostawczy marki Ford produkowany od 1965 roku występujący w różnych typach nadwozi od dostawczego aż po 17-osobowego busa. Auto zastąpiło Forda Thames. Dwa razy zdobył nagrodę Van of the Year - w 2001 oraz 2007 roku. Obecnie produkowana jest VIII generacja modelu.",
                GearboxType = Gearbox.Manual,
                NumberOfSeats = 3,
                EngineCapacity = 1995.00,
                Body = BodyType.VAN,
                Grade = grades[6],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_8.png")
            },
            new Car
            {
                Mark = "Renault",
                Model = "Master",
                Fuel = FuelType.Diesel,
                Description = "Renault Master − rodzina dużych samochodów dostawczych oraz od 2010 roku lekkich samochodów ciężarowych produkowana przez koncern Renault od 1981 roku. Od 2010 roku produkowana jest trzecia generacja.",
                GearboxType = Gearbox.Manual,
                NumberOfSeats = 3,
                EngineCapacity = 2198.00,
                Body = BodyType.PickUp,
                Grade = grades[6],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_9.jpg")
            },
            new Car
            {
                Mark = "Renault",
                Model = "Kadjar",
                Fuel = FuelType.Benzyna,
                Description = "Renault Kadjar – samochód osobowy typu kompaktowy crossover produkowany przez francuski koncern motoryzacyjny Renault od 2015 roku.",
                GearboxType = Gearbox.Manual,
                NumberOfSeats = 5,
                EngineCapacity = 1.2,
                Body = BodyType.SUV,
                Grade = grades[5],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_10.jpg")
            },
            new Car
            {
                Mark = "Skoda",
                Model = "Superb",
                Fuel = FuelType.Diesel,
                Description = "Skoda Superb – samochód osobowy klasy średniej produkowany przez niemiecki koncern motoryzacyjny Volkswagen AG pod czeską marką Škoda Auto od 2001 roku. Od 2015 roku produkowana jest trzecia generacja pojazdu.",
                GearboxType = Gearbox.Automat,
                NumberOfSeats = 5,
                EngineCapacity = 1968.00,
                Body = BodyType.Sedan,
                Grade = grades[3],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_11.png")
            },
            new Car
            {
                Mark = "Ford",
                Model = "Mondeo",
                Fuel = FuelType.Gaz,
                Description = "Ford Mondeo – samochód osobowy klasy średniej produkowany przez Ford Motor Company od 1993 roku. Nazwa Mondeo pochodzi od łacińskiego słowa mundus, które oznacza świat[1]. Od 2012 roku produkowana jest V generacja pojazdu.",
                GearboxType = Gearbox.Manual,
                NumberOfSeats = 5,
                EngineCapacity = 1598.00,
                Body = BodyType.Hatchback,
                Grade = grades[3],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_12.png")
            },
            new Car
            {
                Mark = "Ford",
                Model = "Transit",
                Fuel = FuelType.Diesel,
                Description = "Ford Transit − samochód dostawczy marki Ford produkowany od 1965 roku występujący w różnych typach nadwozi od dostawczego aż po 17-osobowego busa. Auto zastąpiło Forda Thames. Dwa razy zdobył nagrodę Van of the Year - w 2001 oraz 2007 roku. Obecnie produkowana jest VIII generacja modelu.",
                GearboxType = Gearbox.Manual,
                NumberOfSeats = 3,
                EngineCapacity = 1995.00,
                Body = BodyType.VAN,
                Grade = grades[6],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_13.png")
            },
            new Car
            {
                Mark = "Mercedes",
                Model = "Benz A200",
                Fuel = FuelType.Benzyna,
                Description = "Mercedes-Benz – niemiecka marka samochodów produkowanych przez koncern Daimler AG, zaś wcześniej przez koncern Daimler-Benz, popularnie nazywana Mercedes. Pod marką tą produkowane są samochody osobowe, dostawcze, ciężarowe i autobusy. W kategorii samochodów osobowych, Mercedes-Benz uważany jest za jedną z najbardziej prestiżowych marek na świecie, zarazem jedną z najstarszych.",
                GearboxType = Gearbox.Automat,
                NumberOfSeats = 5,
                EngineCapacity = 1598.00,
                Body = BodyType.Hatchback,
                Grade = grades[4],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_14.png")
            },
            new Car
            {
                Mark = "BMW",
                Model = "118i",
                Fuel = FuelType.Benzyna,
                Description = "",
                GearboxType = Gearbox.Automat,
                NumberOfSeats = 5,
                EngineCapacity = 1499.00,
                Body = BodyType.Hatchback,
                Grade = grades[4],
                Year = 2018,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_15.jpg")
            },
            new Car
            {
                Mark = "BMW",
                Model = "318i",
                Fuel = FuelType.Benzyna,
                Description = "",
                GearboxType = Gearbox.Automat,
                NumberOfSeats = 5,
                EngineCapacity = 1499.00,
                Body = BodyType.Sedan,
                Grade = grades[4],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_16.jpg")
            },
            new Car
            {
                Mark = "BMW",
                Model = "X1 S-drive 18i",
                Fuel = FuelType.Benzyna,
                Description = "",
                GearboxType = Gearbox.Automat,
                NumberOfSeats = 5,
                EngineCapacity = 1499,
                Body = BodyType.Sedan,
                Grade = grades[4],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_17.jpg")
            },
            new Car
            {
                Mark = "Mercedes",
                Model = "C180",
                Fuel = FuelType.Benzyna,
                Description = "",
                GearboxType = Gearbox.Automat,
                NumberOfSeats = 5,
                EngineCapacity = 1596,
                Body = BodyType.Sedan,
                Grade = grades[4],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_18.png")
            },
            new Car
            {
                Mark = "Mercedes",
                Model = "CLA",
                Fuel = FuelType.Benzyna,
                Description = "",
                GearboxType = Gearbox.Manual,
                NumberOfSeats = 5,
                EngineCapacity = 1595,
                Body = BodyType.Sedan,
                Grade = grades[4],
                Year = 2017,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_19.png")
            },
            new Car
            {
                Mark = "Audi",
                Model = "A6",
                Fuel = FuelType.Benzyna,
                Description = "Audi A6 − samochód osobowy klasy premium produkowany od 1994 roku przez markę Audi. Od 2018 roku produkowana jest piąta generacja pojazdu oznaczona symbolem C8",
                GearboxType = Gearbox.Automat,
                NumberOfSeats = 5,
                EngineCapacity = 1968,
                Body = BodyType.Sedan,
                Grade = grades[5],
                Year = 2018,
                Img = ImgConverter.ImgToByte(directoryName+"\\wwwroot\\img\\tmp\\car_20.png")
            }
            };
            if (!dbContext.GetCars.Any())
            {
                dbContext.GetCars.AddRange(cars);
                dbContext.SaveChanges();
            }

            var carsDetal = new List<CarDetails>
            {
                new CarDetails{Location=locations[0], Car=cars[0], State=StateType.Sprawny, RegistrationNumber="WI027HJ"},
                new CarDetails{Location=locations[0], Car=cars[1], State=StateType.Sprawny, RegistrationNumber="WI037HJ"},
                new CarDetails{Location=locations[0], Car=cars[2], State=StateType.Sprawny, RegistrationNumber="WI047HJ"},
                new CarDetails{Location=locations[0], Car=cars[3], State=StateType.Sprawny, RegistrationNumber="WI057HJ"},
                new CarDetails{Location=locations[0], Car=cars[3], State=StateType.Sprawny, RegistrationNumber="WI067HJ"},
                new CarDetails{Location=locations[0], Car=cars[3], State=StateType.Sprawny, RegistrationNumber="WI077HJ"},
                new CarDetails{Location=locations[0], Car=cars[4], State=StateType.Sprawny, RegistrationNumber="WI087HJ"},
                new CarDetails{Location=locations[0], Car=cars[4], State=StateType.Sprawny, RegistrationNumber="WI097HJ"},
                new CarDetails{Location=locations[0], Car=cars[12], State=StateType.Sprawny, RegistrationNumber="WI022HJ"},
                new CarDetails{Location=locations[0], Car=cars[12], State=StateType.Sprawny, RegistrationNumber="WI032HJ"},
                new CarDetails{Location=locations[0], Car=cars[12], State=StateType.Sprawny, RegistrationNumber="WI042HJ"},

                new CarDetails{Location=locations[1], Car=cars[19], State=StateType.Sprawny, RegistrationNumber="KR027HJ"},
                new CarDetails{Location=locations[1], Car=cars[19], State=StateType.Sprawny, RegistrationNumber="KR037HJ"},
                new CarDetails{Location=locations[1], Car=cars[19], State=StateType.Sprawny, RegistrationNumber="KR047HJ"},
                new CarDetails{Location=locations[1], Car=cars[19], State=StateType.Sprawny, RegistrationNumber="KR057HJ"},
                new CarDetails{Location=locations[1], Car=cars[19], State=StateType.Sprawny, RegistrationNumber="KR067HJ"},
                new CarDetails{Location=locations[1], Car=cars[13], State=StateType.Sprawny, RegistrationNumber="KR077HJ"},
                new CarDetails{Location=locations[1], Car=cars[13], State=StateType.Sprawny, RegistrationNumber="KR087HJ"},
                new CarDetails{Location=locations[1], Car=cars[14], State=StateType.Sprawny, RegistrationNumber="KR097HJ"},
                new CarDetails{Location=locations[1], Car=cars[12], State=StateType.Sprawny, RegistrationNumber="KR022HJ"},
                new CarDetails{Location=locations[1], Car=cars[12], State=StateType.Sprawny, RegistrationNumber="KR032HJ"},
                new CarDetails{Location=locations[1], Car=cars[12], State=StateType.Sprawny, RegistrationNumber="KR042HJ"},
                new CarDetails{Location=locations[1], Car=cars[10], State=StateType.Sprawny, RegistrationNumber="KR027HJ"},
                new CarDetails{Location=locations[1], Car=cars[10], State=StateType.Sprawny, RegistrationNumber="KR037HJ"},
                new CarDetails{Location=locations[1], Car=cars[10], State=StateType.Sprawny, RegistrationNumber="KR047HJ"},
                new CarDetails{Location=locations[1], Car=cars[7], State=StateType.Sprawny, RegistrationNumber="KR057HJ"},
                new CarDetails{Location=locations[1], Car=cars[8], State=StateType.Sprawny, RegistrationNumber="KR067HJ"},
                new CarDetails{Location=locations[1], Car=cars[9], State=StateType.Sprawny, RegistrationNumber="KR077HJ"},
                new CarDetails{Location=locations[1], Car=cars[4], State=StateType.Sprawny, RegistrationNumber="KR087HJ"},
                new CarDetails{Location=locations[1], Car=cars[4], State=StateType.Sprawny, RegistrationNumber="KR097HJ"},
                new CarDetails{Location=locations[1], Car=cars[17], State=StateType.Sprawny, RegistrationNumber="KR022HJ"},
                new CarDetails{Location=locations[1], Car=cars[17], State=StateType.Sprawny, RegistrationNumber="KR032HJ"},
                new CarDetails{Location=locations[1], Car=cars[17], State=StateType.Sprawny, RegistrationNumber="KR042HJ"},

                new CarDetails{Location=locations[2], Car=cars[0], State=StateType.Sprawny, RegistrationNumber="WI127HJ"},
                new CarDetails{Location=locations[2], Car=cars[1], State=StateType.Sprawny, RegistrationNumber="WI137HJ"},
                new CarDetails{Location=locations[2], Car=cars[2], State=StateType.Sprawny, RegistrationNumber="WI147HJ"},
                new CarDetails{Location=locations[2], Car=cars[3], State=StateType.Sprawny, RegistrationNumber="WI157HJ"},
                new CarDetails{Location=locations[2], Car=cars[4], State=StateType.Sprawny, RegistrationNumber="WI167HJ"},
                new CarDetails{Location=locations[2], Car=cars[5], State=StateType.Sprawny, RegistrationNumber="WI177HJ"},
                new CarDetails{Location=locations[2], Car=cars[6], State=StateType.Sprawny, RegistrationNumber="WI187HJ"},
                new CarDetails{Location=locations[2], Car=cars[7], State=StateType.Sprawny, RegistrationNumber="WI197HJ"},
                new CarDetails{Location=locations[2], Car=cars[8], State=StateType.Sprawny, RegistrationNumber="WI122HJ"},
                new CarDetails{Location=locations[2], Car=cars[9], State=StateType.Sprawny, RegistrationNumber="WI132HJ"},
                new CarDetails{Location=locations[2], Car=cars[10], State=StateType.Sprawny, RegistrationNumber="WI142HJ"},
                new CarDetails{Location=locations[2], Car=cars[11], State=StateType.Sprawny, RegistrationNumber="WI127HJ"},
                new CarDetails{Location=locations[2], Car=cars[12], State=StateType.Sprawny, RegistrationNumber="WI137HJ"},
                new CarDetails{Location=locations[2], Car=cars[13], State=StateType.Sprawny, RegistrationNumber="WI147HJ"},
                new CarDetails{Location=locations[2], Car=cars[14], State=StateType.Sprawny, RegistrationNumber="WI157HJ"},
                new CarDetails{Location=locations[2], Car=cars[15], State=StateType.Sprawny, RegistrationNumber="WI167HJ"},
                new CarDetails{Location=locations[2], Car=cars[16], State=StateType.Sprawny, RegistrationNumber="WI177HJ"},
                new CarDetails{Location=locations[2], Car=cars[17], State=StateType.Sprawny, RegistrationNumber="WI187HJ"},
                new CarDetails{Location=locations[2], Car=cars[18], State=StateType.Sprawny, RegistrationNumber="WI197HJ"},
                new CarDetails{Location=locations[2], Car=cars[19], State=StateType.Sprawny, RegistrationNumber="WI122HJ"},
                new CarDetails{Location=locations[2], Car=cars[19], State=StateType.Uszkodzony, RegistrationNumber="WI132HJ"},
                new CarDetails{Location=locations[2], Car=cars[19], State=StateType.Uszkodzony, RegistrationNumber="WI142HJ"},

                new CarDetails{Location=locations[3], Car=cars[4], State=StateType.Sprawny, RegistrationNumber="SK127HJ"},
                new CarDetails{Location=locations[3], Car=cars[4], State=StateType.Sprawny, RegistrationNumber="SK137HJ"},
                new CarDetails{Location=locations[3], Car=cars[7], State=StateType.Sprawny, RegistrationNumber="SK147HJ"},
                new CarDetails{Location=locations[3], Car=cars[7], State=StateType.Sprawny, RegistrationNumber="SK157HJ"},
                new CarDetails{Location=locations[3], Car=cars[7], State=StateType.Sprawny, RegistrationNumber="SK167HJ"},
                new CarDetails{Location=locations[3], Car=cars[9], State=StateType.Sprawny, RegistrationNumber="SK177HJ"},
                new CarDetails{Location=locations[3], Car=cars[9], State=StateType.Sprawny, RegistrationNumber="SK187HJ"},
                new CarDetails{Location=locations[3], Car=cars[10], State=StateType.Sprawny, RegistrationNumber="SK197HJ"},
                new CarDetails{Location=locations[3], Car=cars[11], State=StateType.Sprawny, RegistrationNumber="SK122HJ"},
                new CarDetails{Location=locations[3], Car=cars[11], State=StateType.Sprawny, RegistrationNumber="SK132HJ"},
                new CarDetails{Location=locations[3], Car=cars[11], State=StateType.Sprawny, RegistrationNumber="SK142HJ"},
                new CarDetails{Location=locations[3], Car=cars[11], State=StateType.Sprawny, RegistrationNumber="SK127HJ"},
                new CarDetails{Location=locations[3], Car=cars[18], State=StateType.Sprawny, RegistrationNumber="SK137HJ"},
                new CarDetails{Location=locations[3], Car=cars[18], State=StateType.Sprawny, RegistrationNumber="SK147HJ"},
                new CarDetails{Location=locations[3], Car=cars[18], State=StateType.Sprawny, RegistrationNumber="SK157HJ"},

                new CarDetails{Location=locations[4], Car=cars[1], State=StateType.Sprawny, RegistrationNumber="ZSZ197HJ"},
                new CarDetails{Location=locations[4], Car=cars[1], State=StateType.Sprawny, RegistrationNumber="ZSZ122HJ"},
                new CarDetails{Location=locations[4], Car=cars[1], State=StateType.Sprawny, RegistrationNumber="ZSZ132HJ"},
                new CarDetails{Location=locations[4], Car=cars[2], State=StateType.Sprawny, RegistrationNumber="ZSZ142HJ"},
                new CarDetails{Location=locations[4], Car=cars[2], State=StateType.Sprawny, RegistrationNumber="ZSZ127HJ"},
                new CarDetails{Location=locations[4], Car=cars[2], State=StateType.Sprawny, RegistrationNumber="ZSZ137HJ"},
                new CarDetails{Location=locations[4], Car=cars[3], State=StateType.Sprawny, RegistrationNumber="ZSZ147HJ"},
                new CarDetails{Location=locations[4], Car=cars[3], State=StateType.Sprawny, RegistrationNumber="ZSZ157HJ"},

                new CarDetails{Location=locations[5], Car=cars[1], State=StateType.Sprawny, RegistrationNumber="LU197HJ"},
                new CarDetails{Location=locations[5], Car=cars[2], State=StateType.Sprawny, RegistrationNumber="LU122HJ"},
                new CarDetails{Location=locations[5], Car=cars[3], State=StateType.Sprawny, RegistrationNumber="LU132HJ"},
                new CarDetails{Location=locations[5], Car=cars[6], State=StateType.Uszkodzony, RegistrationNumber="LU142HJ"},
                new CarDetails{Location=locations[5], Car=cars[10], State=StateType.Sprawny, RegistrationNumber="LU127HJ"},
                new CarDetails{Location=locations[5], Car=cars[15], State=StateType.Sprawny, RegistrationNumber="LU137HJ"},
                new CarDetails{Location=locations[5], Car=cars[18], State=StateType.Sprawny, RegistrationNumber="LU147HJ"},
                new CarDetails{Location=locations[5], Car=cars[19], State=StateType.Sprawny, RegistrationNumber="LU157HJ"},
            };
            if (!dbContext.GetCarDetails.Any())
            {
                dbContext.GetCarDetails.AddRange(carsDetal);
                dbContext.SaveChanges();
            }
        }
            
    }
}
     

