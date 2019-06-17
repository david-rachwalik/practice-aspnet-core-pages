using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages.Student
{
    public class DetailsModel : PageModel
    {
        //private readonly SchoolContext _context;
        private readonly IStudentService _studentService;

        public DetailsModel(IStudentService studentService)
        {
            //_context = context;
            _studentService = studentService;
        }

        public Models.Student Student { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) { return NotFound(); }

            //Student = await _context.Student.FirstOrDefaultAsync(m => m.Id == id);
            Student = await _studentService.OnGetAsync(id);

            if (Student == null) { return NotFound(); }
            return Page();
        }
    }
}
