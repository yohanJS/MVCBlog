using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Data;
using MVCBlog.Models;

namespace MVCBlog.Controllers
{
    public class BlogsController : Controller
    {
        private readonly MVCBlogContext _context;

        public BlogsController(MVCBlogContext context)
        {
            _context = context;
        }

        // GET: Blogs
        public IActionResult Index()
        {
            return View();  
        }

        public async Task<IActionResult> AllBlogs(string searchString)
        {

            if (_context.Blog == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }
            // creates a LINQ query to select the movies:
            var blogs = from blog in _context.Blog
                        select blog;

            if (!String.IsNullOrEmpty(searchString))
            {
                blogs = blogs.Where(s => s.Category!.Contains(searchString));
            }

            return View(await blogs.ToListAsync());

        }

        // GET: Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var blog = await _context.Blog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(blog);
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Author,Content,CreatedDate, Category")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllBlogs));
            }
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var blog = await _context.Blog.FindAsync(id);
            if (blog == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Author,Content,CreatedDate,Category")] Blog blog)
        {
            if (id != blog.Id)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.Id))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var blog = await _context.Blog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Blog == null)
            {
                return Problem("Entity set 'MVCBlogContext.Blog'  is null.");
            }
            var blog = await _context.Blog.FindAsync(id);
            if (blog != null)
            {
                _context.Blog.Remove(blog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
          return (_context.Blog?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
