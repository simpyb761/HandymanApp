using Microsoft.AspNetCore.Identity;

namespace Handyman.Data {

    public class ApplicationUser : IdentityUser{
        public string? Name { get; set; }
      
    }
}
