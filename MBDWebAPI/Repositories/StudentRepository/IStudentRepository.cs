using Web_API.Modals;

namespace Web_API.Repositories.StudentRepository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<bool> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<bool> DeleteStudentById(int id);
    }
}
