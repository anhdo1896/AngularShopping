using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Anh Do",
                    Email = "anhdongoc18@gmail.com",
                    UserName = "anhdongoc18@gmail.com",
                    Address = new Address
                    {
                        FirstName = "Anh",
                        LastName = "Do",
                        Street = "32 Trung Hoa",
                        City = "Hanoi",
                        State = "CauGiay",
                        ZipCode = "100000"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }

        }

    }
}