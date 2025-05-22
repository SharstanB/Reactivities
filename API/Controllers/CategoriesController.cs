using Application.Categories.Queries;
using Application.Cities.Queries;
using Application.DataTransferObjects;
using Application.Validators;
using Domain.Services.Validation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseAppController
    {
        [HttpGet]
        public async Task<ActionResult<OperationResult<List<BasicListDTO>>>> GetCities()
        {
            var cities = await Mediator.Send(new GetCategoriesList.Query());
            return cities;
        }
       
    }
}
