
using System.Collections.Generic;
using System.Linq;
using CarRent.Data.Repo;
using CarRent.Models;
using CarRent.Controllers;
using CarRent.Models.ViewModel;
using Xunit;
using Moq;

namespace CaRentTest
{
    public class CarControllerTest
    {
        [Fact]
        public void Can_FilterCarByGrade()
        {
            //Utworzenie imitacji repozytorium
            var grades=new List<Grade>
            {
                new Grade{Grade_ID=1, GradeType=GradeType.A},
                new Grade{Grade_ID=2, GradeType=GradeType.B},
                new Grade{Grade_ID=3, GradeType=GradeType.C},
                new Grade{Grade_ID=4, GradeType=GradeType.D},
                new Grade{Grade_ID=5, GradeType=GradeType.Premium},
                new Grade{Grade_ID=6, GradeType=GradeType.SUV},
                new Grade{Grade_ID=7, GradeType=GradeType.BUS}
            };
            Mock<ICarRepo> mock_Car = new Mock<ICarRepo>();
            mock_Car.Setup(m => m.GetAll()).Returns((new Car[] {
                new Car{Car_ID=1, Mark="Marka1", Model="Model1", GradeID=1},
                new Car{Car_ID=1, Mark="Marka1", Model="Model1", GradeID=2},
                new Car{Car_ID=1, Mark="Marka1", Model="Model1", GradeID=1},
                new Car{Car_ID=1, Mark="Marka1", Model="Model1", GradeID=7},
                new Car{Car_ID=1, Mark="Marka1", Model="Model1", GradeID=7}
            }).AsQueryable<Car>());

            //Przygotowanie kontrolera i ustawienie 3 elementowej strony
            CarController controller = new CarController(mock_Car.Object);
            controller.PageSize = 3;

            //Działanie
            Car[] result =
                (controller.CarsList("A", 1).ViewData.Model as CarListView).Cars.ToArray();

            //Asercje
            Assert.Equal(2, result.Length);
        }
    }
}