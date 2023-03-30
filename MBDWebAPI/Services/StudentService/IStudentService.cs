using Web_API.Modals;

namespace Web_API.Services.StudentService
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<bool> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<bool> DeleteStudentById(int id);
    }
}
