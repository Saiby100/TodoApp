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
    public class DetailsModel : PageModel
    {
        private readonly TodoApp.Data.ApplicationDbContext _context;

        public DetailsModel(TodoApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TodoItem TodoItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoitem = await _context.TodoItem.FirstOrDefaultAsync(m => m.Id == id);
            if (todoitem == null)
            {
                return NotFound();
            }
            else
            {
                TodoItem = todoitem;
            }
            return Page();
        }
    }
}
