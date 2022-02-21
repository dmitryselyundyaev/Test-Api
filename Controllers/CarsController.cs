using CmdApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CmdApi.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        public readonly CarContext _context;
        public CarsController(CarContext context) => _context = context;

        ///GET:   All cars in db.
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAllData()
        {
            return _context.Cars;
        }

        ///GET: Car by id from db.
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

        ///POST:   Post new car to db.
        [HttpPost]
        public ActionResult<Car> SetData(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return car;
        }


        ///PUT:      Update car info by using id.
        [HttpPut("{id}")]
        public ActionResult<Car> UpdateData(Car car, int id)
        {
            var Car = _context.Cars.Find(id);
            Car.Model = car.Model;
            Car.PlateNumber = car.PlateNumber;
            _context.Update(Car);
            _context.SaveChanges();
            return Car;
        }



        ///DELETE:       Delete car using id.
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
