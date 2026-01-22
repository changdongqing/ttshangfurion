using TTShang.Core.Entities;

namespace TTShang.Application.Services;

/// <summary>
/// Student service interface
/// </summary>
public interface IStudentService
{
    /// <summary>
    /// Get all students
    /// </summary>
    Task<List<Student>> GetAllAsync();

    /// <summary>
    /// Get student by ID
    /// </summary>
    Task<Student?> GetByIdAsync(Guid id);

    /// <summary>
    /// Add a new student
    /// </summary>
    Task<Student> AddAsync(Student student);

    /// <summary>
    /// Update an existing student
    /// </summary>
    Task<Student> UpdateAsync(Student student);

    /// <summary>
    /// Delete a student by ID
    /// </summary>
    Task<bool> DeleteAsync(Guid id);
}
