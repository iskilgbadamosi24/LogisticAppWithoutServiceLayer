using Shipping_System.Data;
using Shipping_System.Models;
using System;

namespace Shipping_System.Repository.CountryRepo
{
    public class CountryRepository : ICountryRepository  
    {
        ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public void Add(Country countryrepo)
        {
            _context.Countries.Add(countryrepo);
        }

        public void Delete(int id)
        {
            Country country = GetById(id);
            _context.Countries.Remove(country);

        }

        public void Edit(Country country)
        {
            _context.Entry(country).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<Country> GetAll()
        {
            return _context.Countries.ToList();
        }

        public Country GetById(int id)
        {
            return _context.Countries.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
