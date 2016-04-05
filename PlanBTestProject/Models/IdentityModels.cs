using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace PlanBTestProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public ApplicationUser()
        {
            Skills = new HashSet<Skill>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Skill> Skills { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Skill>()
                .HasMany(c => c.Users)
                .WithMany()
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("SkillId");
                    cs.ToTable("SkillApplicationUsers");
                });
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public static bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return rm.RoleExists(name);
        }


        public static bool CreateRole(string name)
        {
            if (!RoleExists(name))
            {
                var rm = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new ApplicationDbContext()));
                var idResult = rm.Create(new IdentityRole(name));
                return idResult.Succeeded;
            }
            return false;
        }


        public static bool AddUserToRole(string userId, string roleName)
        {
            CreateRole(roleName);
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }


        //public void ClearUserRoles(string userId)
        //{
        //    var um = new UserManager<ApplicationUser>(
        //        new UserStore<ApplicationUser>(new ApplicationDbContext()));
        //    var user = um.FindById(userId);
        //    var currentRoles = new List<IdentityUserRole>();
        //    currentRoles.AddRange(user.Roles);
        //    foreach (var role in currentRoles)
        //    {
        //        um.RemoveFromRole(userId, Re);
        //    }
        //}
    }
}