using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Models;

namespace MVCBlog.Data
{
    public class MVCBlogContext : DbContext
    {
        public MVCBlogContext (DbContextOptions<MVCBlogContext> options)
            : base(options)
        {
        }

        public DbSet<MVCBlog.Models.Blog> Blog { get; set; } = default!;
    }
}
