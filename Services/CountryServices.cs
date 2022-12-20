using CodeFirstApi.Interfaces;
using CodeFirstApi.Request;
using DB;

namespace CodeFirstApi.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly TestEFContext _context;
        public CountryServices(TestEFContext context)
        {
            this._context = context;
        }

        public int createCountry(CountryRequest country)
        {
            var res = 0;
            var countryTeam = new CountryTeam();
            countryTeam.Name = country.Name;
            countryTeam.GroupId = country.GroupId;

            this._context.CountryTeams.Add(countryTeam);

            try
            {
                res = this._context.SaveChanges();
            }
            catch (Exception e)
            {

                res = -1;
            }

            return res;
        }

        public List<CountryTeam> getcountries()
        {
            this._context.SaveChanges();
            return this._context.CountryTeams.ToList();

        }
    }
}
