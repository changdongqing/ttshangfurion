using Furion.DependencyInjection;
using TTShang.Core.Entities;
using TTShang.Core.Repositories;

namespace TTShang.Application.Services;

/// <summary>
/// Student service implementation
/// </summary>
public class StudentService : IStudentService, ITransient
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    /// <summary>
    /// Get all students
    /// </summary>
    public async Task<List<Student>> GetAllAsync()
    {
        return await _studentRepository.GetAllAsync();
    }

    /// <summary>
    /// Get student by ID
    /// </summary>
    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await _studentRepository.GetByIdAsync(id);
    }

    /// <summary>
    /// Add a new student
    /// </summary>
    public async Task<Student> AddAsync(Student student)
    {
        if (student.Id == Guid.Empty)
        {
            student.Id = Guid.NewGuid();
        }
        return await _studentRepository.AddAsync(student);
    }

    /// <summary>
    /// Update an existing student
    /// </summary>
    public async Task<Student> UpdateAsync(Student student)
    {
        return await _studentRepository.UpdateAsync(student);
    }

    /// <summary>
    /// Delete a student by ID
    /// </summary>
    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _studentRepository.DeleteAsync(id);
    }
}
