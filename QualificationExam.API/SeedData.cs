using Microsoft.AspNetCore.Identity;
using QualificationExam.Domain.Constants;
using QualificationExam.Domain.Enitities.Identity;
using QualificationExam.Infrastructure;


namespace QualificationExam.API
{
    public static class SeedData
    {
        public static async Task SeedAsync(WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

            string[] roles = { Roles.USER, Roles.ADMIN };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new AppRole() { Name = role });
            }
        }
    }
}
