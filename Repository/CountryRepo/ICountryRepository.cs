using Shipping_System.Models;

namespace Shipping_System.Repository.CountryRepo
{
    public interface ICountryRepository 
    {
        List<Country> GetAll();
        Country GetById(int id);
        void Add(Country countryrep);
        void Edit(Country countryrep);
        void Delete(int id);
        void Save();
    }
}
