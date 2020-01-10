using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AviationEducation.Models;

namespace AviationEducation.Data
{
    public class AviationEducationContext : DbContext
    {
        public AviationEducationContext (DbContextOptions<AviationEducationContext> options)
            : base(options)
        {
        }

        public DbSet<AviationEducation.Models.Question> Question { get; set; }
    }
}
