using CodeFirstApi.Request;
using DB;

namespace CodeFirstApi.Interfaces
{
    public interface ICountryServices
    {
        List<CountryTeam> getcountries();
        int createCountry(CountryRequest country);
    }
}
