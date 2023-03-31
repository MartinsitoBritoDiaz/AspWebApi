using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_API.Modals;
using Web_API.Repositories.StudentRepository;

namespace Web_API.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IConfiguration _configuration;

        IStudentRepository _studentRepository;
        public StudentService(IConfiguration configuration, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _configuration = configuration;
        }

        public async Task<bool> CreateStudent(Student student)
        {
            try
            {
                if ( !verifyFields(student) )
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
        private bool verifyFields(Student student)
        {
            bool verified = true;

            if (student.Name.IsNullOrEmpty())
            {
                verified = false;
                throw new Exception("Must provide the NAME of this student");
            }

            if (student.Age <= 0)
            {
                verified = false;
                throw new Exception("You must enter a valid age");
            }


            return verified;
        }

        private string CreateToken(User user)
        {
            //Create the claims with the roles
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            //Encode the information with the secret string
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //Set the claims, expire date and the cre dentials to the token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
