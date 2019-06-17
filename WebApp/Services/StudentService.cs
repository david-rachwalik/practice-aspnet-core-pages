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
        Task<Student> ReadAsync();
        Task<Student> ReadAsync(int? id);
        Task<IList<Student>> ReadListAsync();
        Task<int> CreateAsync(Student student);
        Task<int> DeleteAsync(int? id);
        Task<int> UpdateAsync(Student student);
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
        public async Task<Student> ReadAsync(int? id)
        {
            if (id == null) { return null; }
            Student student = await _context.Student.FirstOrDefaultAsync(m => m.Id == id);
            return await Task.FromResult(student);
        }
        public async Task<Student> ReadAsync()
        {
            return await Task.FromResult(await ReadAsync(testId));
        }

        public async Task<IList<Student>> ReadListAsync()
        {
            IList<Student> students = new List<Student>();

            // TODO: add Version dropdown for Admin
            //students = students.Where(m => m.Version.Equals(WebApp.Models.Version.Core)).ToList();
            students = await _context.Student.ToListAsync();

            return await Task.FromResult(students);
        }

        public async Task<int> CreateAsync(Student student)
        {
            _context.Student.Add(student);
            int changes = await _context.SaveChangesAsync();

            return await Task.FromResult(changes);
        }

        public async Task<int> UpdateAsync(Student student)
        {
            _context.Attach(student).State = EntityState.Modified;
            int changes = await _context.SaveChangesAsync();
            
            return await Task.FromResult(changes);
        }

        public async Task<int> DeleteAsync(int? id)
        {
            int changeCount = 0;
            Student student = await ReadAsync(id);

            if (student != null)
            {
                _context.Student.Remove(student);
                changeCount = await _context.SaveChangesAsync();
            }

            return await Task.FromResult(changeCount);
        }
    }
}
