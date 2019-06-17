using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages.Student
{
    public class EditModel : PageModel
    {
        //private readonly SchoolContext _context;
        private readonly IStudentService _studentService;

        public EditModel(IStudentService studentService)
        {
            //_context = context;
            _studentService = studentService;
        }

        [BindProperty]
        public Models.Student Student { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) { return NotFound(); }

            //Student = await _context.Student.FirstOrDefaultAsync(m => m.Id == id);
            Student = await _studentService.ReadAsync(id);

            if (Student == null) { return NotFound(); }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }

            //_context.Attach(Student).State = EntityState.Modified;
            await _studentService.UpdateAsync(Student);
            
            return RedirectToPage("./Index");
        }
    }
}
