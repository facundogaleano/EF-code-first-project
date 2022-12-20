using CodeFirstApi.Interfaces;
using CodeFirstApi.Request;
using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryServices _countryServices;

        public CountryController(ICountryServices countryServices)
        {
            this._countryServices = countryServices;
        }

        [HttpPost]
        public IActionResult CreateCounry([FromBody] CountryRequest country)
        {
            try
            {
                var result = this._countryServices.createCountry(country);
                if(result > 0)
                {
                    return Ok("Selección ingresada con éxito");
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception e)
            {

                return BadRequest("Error ===> " + e);
            }
        }
        [HttpGet]
        public IActionResult GetCountries()
        {
            try
            {
                var listOfCountries = this._countryServices.getcountries();
                return Ok(listOfCountries);
            }
            catch (Exception e)
            {
                return BadRequest("Error");
            }
        }
    }
}
