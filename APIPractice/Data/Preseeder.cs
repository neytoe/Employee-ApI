using APIPractice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice.Data
{
    public static class Preseeder
    {
        public async static Task Seeder(EmployeeContext ctx)
        {
            ctx.Database.EnsureCreated();
            if (!ctx.Roles.Any())
            {
                var listOfRole = new List<Role>
                {
                    new Role{Id = 1, Name = "Admin"},
                    new Role { Id =2, Name = "User" }
                };

                foreach (var item in listOfRole)
                {
                    await ctx.Roles.AddAsync(item);
                    await ctx.SaveChangesAsync();
                }
            }
        }

        
    }
}
