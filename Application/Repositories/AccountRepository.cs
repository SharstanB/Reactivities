using Microsoft.AspNetCore.Identity;
using Persistence.IdentityEnitities;

namespace Application.Repositories
{
    public class AccountRepository(SignInManager<AppUser> userManager)
    {
       
    }
}
