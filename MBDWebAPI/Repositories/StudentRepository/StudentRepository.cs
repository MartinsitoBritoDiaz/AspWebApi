using Microsoft.EntityFrameworkCore;
using Web_API.Data.Context;
using Web_API.Modals;

namespace Web_API.Repositories.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Context _context;

        public StudentRepository(Context context)
        {
            _context = context;
        }
        public async Task<bool> Create(Student student)
        {
            try
            {
                await _context.Student.AddAsync(student);
                var isSaved = _context.SaveChanges() > 0 ? true : false;

                if (!isSaved)
                    throw new Exception("Student couldn't be saved");

                return isSaved;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Student>> GetAll()
        {
            try
            {
                return await _context.Student.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Student> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
