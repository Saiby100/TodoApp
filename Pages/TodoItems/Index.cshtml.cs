using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Models.Pages.TodoItems
{
    public class IndexModel : PageModel
    {
        private readonly TodoApp.Data.ApplicationDbContext _context;

        public IndexModel(TodoApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TodoItem> TodoItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TodoItem = await _context.TodoItem.ToListAsync();
        }
    }
}
