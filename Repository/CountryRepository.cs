using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _dataContext;

        public CountryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CountryExists(int id)
        {
            return _dataContext.Countries.Any(c => c.Id == id);
        }

        public bool CreateCountry(Country country)
        {
            _dataContext.Add(country);
            return Save();
        }

        public bool DeleteCountry(Country country)
        {
            _dataContext.Remove(country);
            return Save();
        }

        public ICollection<Country> GetCountries()
        {
            return _dataContext.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _dataContext.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _dataContext.Owners.Where(c => c.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryid)
        {
            return _dataContext.Owners.Where(c => c.Country.Id == countryid).ToList();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _dataContext.Update(country);
            return Save();
        }
    }
}
