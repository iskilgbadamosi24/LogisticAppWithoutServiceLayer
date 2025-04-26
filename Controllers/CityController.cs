﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shipping_System.Constants;
using Shipping_System.Models;
using Shipping_System.Repository.CityRepo;
using Shipping_System.Repository.CountryRepo;
using System.Security.Policy;

namespace Shipping_System.Controllers
{
    public class CityController : Controller
    {
        ICityRepository _cityRepository;
        ICountryRepository _countryRepository;

        public CityController(ICityRepository cityRepository, ICountryRepository countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        [Authorize(Permissions.City.View)]
        public IActionResult Index()
        {
            List<City> cities;
            cities = _cityRepository.GetAll();

            return View(cities);
        }

        [Authorize(Permissions.City.Create)]
        public IActionResult Create(int id)
        {
            ViewData["CountryList"] = _countryRepository.GetAll();
            return View();
        }

        [Authorize(Permissions.City.Create)]
        [HttpPost]
        public IActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                _cityRepository.Add(city);
                _cityRepository.Save();
                return RedirectToAction("Index");
            }
            ViewData["CountryList"] = _countryRepository.GetAll();
            return View(city);
        }

        [Authorize(Permissions.City.Edit)]
        public IActionResult Edit(int id)
        {
            City city = _cityRepository.GetById(id);
            ViewData["CountryList"] = _countryRepository.GetAll();
            return View(city);
        }

        [Authorize(Permissions.City.Edit)]
        [HttpPost]
        public async Task<IActionResult> Edit(City city)
        {
            if (ModelState.IsValid)
            {
                // Get the existing city from the database
                var existingCity = _cityRepository.GetById(city.Id);

                //  assign the IsDeleted property from the existing city
                city.IsDeleted = existingCity.IsDeleted;

                // Update the other properties of the city
                existingCity.Name = city.Name;
                existingCity.ShippingCost = city.ShippingCost;
                existingCity.PickUpCost = city.PickUpCost;
                existingCity.CountrId = city.CountrId;

                _cityRepository.Edit(existingCity);
                _cityRepository.Save();
                return RedirectToAction("Index");
            }
            ViewData["CountryList"] = _countryRepository.GetAll();
            return View(city);
        }
        //changeState City
        [Authorize(Permissions.City.Delete)]
        public IActionResult changeState(int id)
        {
            City city = _cityRepository.GetById(id);
            if (city == null)
            {
                return NotFound();
            }
            else
            {
                city.IsDeleted = !city.IsDeleted;
                _cityRepository.Save();
                return Ok();
            }
        }
    }
}
