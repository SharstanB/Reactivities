using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Persistence.IdentityEnitities
{
    public class AppUser : IdentityUser
    {
        [Required]
        public Guid Id { get; set; }

        [PersonalData]
        public string? Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
