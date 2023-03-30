﻿using Microsoft.EntityFrameworkCore;
using Web_API.Data.Context;
using Web_API.Modals;
using Web_API.Repositories.PatternRepository;

namespace Web_API.Repositories.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Context _context;
        private Repository<Student> _repository;

        public StudentRepository(Context context)
        {
            _context = context;
            _repository = new Repository<Student>(context);
        }
        public async Task<bool> CreateStudent(Student student)
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

        public async Task<List<Student>> GetStudents()
        {
            try
            {
                return await _repository.GetAll();
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
                return await _repository.GetById(id);
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
                return await _repository.Update(student, student.Id);
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
                return await _repository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
