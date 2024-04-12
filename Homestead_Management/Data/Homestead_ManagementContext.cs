using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Homestead_Management.Models.User;
using Homestead_Management.Models.Animals;

namespace Homestead_Management.Data
{
    public class Homestead_ManagementContext : DbContext
    {
        public Homestead_ManagementContext (DbContextOptions<Homestead_ManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Homestead_Management.Models.User.User> Users { get; set; } = default!;
        public DbSet<Homestead_Management.Models.Animals.AnimalType> AnimalTypes { get; set; } = default!;
        public DbSet<Homestead_Management.Models.Animals.Gender> Genders { get; set; } = default!;
        public DbSet<Homestead_Management.Models.Animals.Animal> Animals { get; set; } = default!;
    }
}
