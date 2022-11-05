using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Text;

namespace CMSWebApi.Models
{
    public class ClaimContext:DbContext
    {
  

        public ClaimContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<Member> members { get; set; }
        public DbSet<Plan> plans{ get; set; }
        public DbSet<MemberPlan> memberPlans { get; set; }
        public DbSet<Claim> claim { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            HMACSHA512 hmac = new HMACSHA512();
            var pas= hmac.ComputeHash(Encoding.UTF8.GetBytes("Babita"));
            var pas2 = hmac.ComputeHash(Encoding.UTF8.GetBytes("Madhavi"));

            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    Id = 101,
                    UserName = "Jethalal",
                    Password = "Babita",
                    Address = "Ahmedabad",
                    State = "Gujrat",
                    Country = "India",
                    PhoneNumber = "66666666",
                    EmailId = "Babita@123",
                    Dob = "2-10-1869",
                    PasswordHash = pas,
                    Key=hmac.Key
                },
                  new Member
                  {
                      Id = 102,
                      UserName = "Bhide",
                      Password = "Madhavi",
                      Address = "Mumbai",
                      State = "Maharashtra",
                      Country = "India",
                      PhoneNumber = "66666667",
                      EmailId = "Madhavi@123",
                      Dob = "3-10-1868",
                      PasswordHash = pas2,
                      Key=hmac.Key
                  }
                ) ;
            modelBuilder.Entity<Plan>().HasData(
            new Plan
            {
                pId = 1,
                pName = "Jeevan Raksha Yojna",
                Duration = "1 years",
                Amount = "1000000"

            },
               new Plan
               {
                   pId = 2,
                   pName = "Health Security Plan ",
                   Duration = "5 years",
                   Amount = "200000"

               }
               );
            modelBuilder.Entity<Claim>().HasData(
           new Claim
           {
               cId = 1,
               Amount=20000,
               ClaimDate="22-10-2022"

           },
              new Claim
              {
                  cId = 2,
                  Amount = 30000,
                  ClaimDate = "23-10-2022"
              }
              );
            modelBuilder.Entity<MemberPlan>().HasData(
         new MemberPlan
         {
             Id = 1,
             MId=101,
             CId=1,
             PId=1

         },
            new MemberPlan
            {
                Id = 2,
                MId = 102,
                CId = 1,
                PId = 2

            }
            );
            ;


        }
    }
}
