using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MusLib.WebAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public Role? Role { get; set; }
        public int? RoleId { get; set; }

    }
}
