using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shipping_System.Constants;
using Shipping_System.Models;
using Shipping_System.Repository.CityRepo;
using Shipping_System.Repository.CountryRepo;

namespace Shipping_System.Controllers
{
    public class CountryController : Controller
    {
        ICountryRepository _countryRepository;
        ICityRepository _cityRepository;
        public CountryController(ICountryRepository countryRepository, ICityRepository cityRepository)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;

        }

        [Authorize(Permissions.Country.View)]
        public IActionResult Index(string word)
        {
            List<Country> countries;
            countries=_countryRepository.GetAll();
            return View(countries);
        }

        [Authorize(Permissions.Country.View)]
        public IActionResult Details(int id)
        {
            var cites = _cityRepository.GetAllCitiesByCountryId(id);
            ViewData["CountryName"] = _countryRepository.GetById(id).Name;
            return View(cites);
        }

        [Authorize(Permissions.Country.Create)]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Permissions.Country.Create)]
        [HttpPost]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _countryRepository.Add(country);
                _countryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        [Authorize(Permissions.Country.Edit)]
        public IActionResult Edit(int id)
        {
            Country country = _countryRepository.GetById(id);
            return View(country);
        }

        [Authorize(Permissions.Country.Edit)]
        [HttpPost]
        public IActionResult Edit(Country country)
        {
            var countriFDB =_countryRepository.GetById(country.Id);
            countriFDB.Name= country.Name;
            if (ModelState.IsValid)
            {
                _countryRepository.Edit(countriFDB);
                _countryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        //changeState country
        [Authorize(Permissions.Country.Delete)]
        public IActionResult changeState(int id)
        {
            Country country = _countryRepository.GetById(id);
            if (country == null)
            {
                return NotFound();
            }
            else
            {
                country.IsDeleted = !country.IsDeleted;
                _countryRepository.Save();
                return Ok();
            }
        }
    }
}
