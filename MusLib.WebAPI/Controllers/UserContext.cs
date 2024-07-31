using Microsoft.EntityFrameworkCore;

namespace MusLib.WebAPI.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            if (Database.EnsureCreated())
            {
                Roles.Add(new Role { Name = "Admin" });
                Roles.Add(new Role { Name = "User" });

                Users.Add(new User { Name = "Иван", RoleId = 1 });
                Users.Add(new User { Name = "Сергей", RoleId = 2 });
                Users.Add(new User { Name = "Петр", RoleId = 2 });
                SaveChanges();
            }
        }
    }

}
