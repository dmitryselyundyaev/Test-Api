using CmdApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdApi.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        public readonly CarContext _context;
        public CarsController(CarContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetData()
        {
            return _context.Cars;
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetDataById(int id)
        {
            var car = _context.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            return car;
        }

        [HttpPost]
        //[ActionName(nameof(SetData))]
        public ActionResult<Car> SetData(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return car;
        }

        [HttpPut("{id}")]
        //[ActionName(nameof(SetData))]
        public ActionResult<Car> UpdateData(Car car,int id)
        {
            var Car = _context.Cars.Find(id);
            Car.Model = car.Model;
            Car.PlateNumber = car.PlateNumber;
            _context.Update(Car);
            _context.SaveChanges();
            return Car;
        }




        [HttpDelete("{id}")]
        public ActionResult<Car> DeleteCarById(int id)
        {
            var car = _context.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return car;
        }
    }

}
