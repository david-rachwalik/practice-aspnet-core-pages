using WebApp.Data;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IStudentService
    {
        Task<Student> OnGetAsync();
        Task<Student> OnGetAsync(int? id);
        Task<IList<Student>> OnGetListAsync();
        Task<int> OnPostAsync(Student student);
        Task<int> OnPullAsync(int? id);
        Task<int> OnPutAsync(Student student);
    }


    public class StudentService : IStudentService
    {
        private const int testId = 1;
        private readonly SchoolContext _context;

        public StudentService(SchoolContext context)
        {
            _context = context;
        }


        // Private Methods
        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
        

        // Public Methods
        public async Task<Student> OnGetAsync(int? id)
        {
            if (id == null) { return null; }
            Student student = await _context.Student.FirstOrDefaultAsync(m => m.Id == id);
            return await Task.FromResult(student);
        }
        public async Task<Student> OnGetAsync()
        {
            return await Task.FromResult(await OnGetAsync(testId));
        }

        public async Task<IList<Student>> OnGetListAsync()
        {
            IList<Student> students = new List<Student>();

            // TODO: add Version dropdown for Admin
            //students = students.Where(m => m.Version.Equals(WebApp.Models.Version.Core)).ToList();
            students = await _context.Student.ToListAsync();

            return await Task.FromResult(students);
        }

        public async Task<int> OnPostAsync(Student student)
        {
            _context.Student.Add(student);
            int changes = await _context.SaveChangesAsync();

            return await Task.FromResult(changes);
        }

        public async Task<int> OnPutAsync(Student student)
        {
            _context.Attach(student).State = EntityState.Modified;
            int changes = await _context.SaveChangesAsync();
            
            return await Task.FromResult(changes);
        }

        public async Task<int> OnPullAsync(int? id)
        {
            int changeCount = 0;
            Student student = await OnGetAsync(id);

            if (student != null)
            {
                _context.Student.Remove(student);
                changeCount = await _context.SaveChangesAsync();
            }

            return await Task.FromResult(changeCount);
        }
    }
}
