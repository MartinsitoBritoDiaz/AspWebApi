using Web_API.Modals;

namespace Web_API.Repositories.StudentRepository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<bool> Create(Student student);
    }
}
