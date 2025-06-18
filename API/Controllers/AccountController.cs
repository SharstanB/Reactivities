using Application.DataTransferObjects.UsersAccounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public Task<ActionResult> RegisterUser(UserRegistrationDTO registrationDTO)
        {
            
            return Ok();
        }
    }
}
