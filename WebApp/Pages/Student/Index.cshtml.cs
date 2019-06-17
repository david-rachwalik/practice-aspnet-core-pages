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
    public class IndexModel : PageModel
    {
        //private readonly SchoolContext _context;
        private readonly IStudentService _studentService;

        public IndexModel(IStudentService studentService)
        {
            //_context = context;
            _studentService = studentService;
        }

        public IList<Models.Student> Student { get;set; }


        public async Task OnGetAsync()
        {
            //Student = await _context.Student.ToListAsync();
            Student = await _studentService.OnGetListAsync();
        }
    }
}
