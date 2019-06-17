using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages.Student
{
    public class CreateModel : PageModel
    {
        //private readonly SchoolContext _context;
        private readonly IStudentService _studentService;

        public CreateModel(IStudentService studentService)
        {
            //_context = context;
            _studentService = studentService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Student Student { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }

            //_context.Student.Add(Student);
            //await _context.SaveChangesAsync();
            await _studentService.CreateAsync(Student);

            return RedirectToPage("./Index");
        }
    }
}
