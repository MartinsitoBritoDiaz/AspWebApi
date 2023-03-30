using Web_API.Modals;
using Web_API.Repositories.StudentRepository;

namespace Web_API.Services.StudentService
{
    public class StudentService : IStudentService
    {
        IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> CreateStudent(Student student)
        {
            try
            {
                if (student == null)
                    throw new Exception("Student couldn't be saved");

                return await _studentRepository.CreateStudent(student);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteStudentById(int id)
        {
            try
            {
                return await _studentRepository.DeleteStudentById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Student> GetStudentById(int id)
        {
            try
            {
                return await _studentRepository.GetStudentById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Student>> GetStudents()
        {
            try
            {
                return await _studentRepository.GetStudents();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            try
            {
                if (student == null)
                    throw new Exception("Student couldn't be updated");

                return await _studentRepository.UpdateStudent(student);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
