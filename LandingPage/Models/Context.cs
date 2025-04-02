using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LandingPage.Models
{
    public class Context : DbContext
    {
       
        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Data Source =.; Initial Catalog = LandingPage_Project; Integrated Security = True; Encrypt = False; Trust Server Certificate = True
            //Server = db15204.public.databaseasp.net; Database=db15204; User Id = db15204; Password=k-8L6S+g_rC4; Encrypt=False; MultipleActiveResultSets=True;
            optionsBuilder.UseSqlServer("Server=db15715.public.databaseasp.net; Database=db15715; User Id=db15715; Password=4Fk=z!H5-M2j; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
  
        }

    }
}
