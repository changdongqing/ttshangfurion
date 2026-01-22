using Furion.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TTShang.Core.Entities;
using TTShang.Core.Repositories;
using TTShang.Database.Adapter.Context;

namespace TTShang.Database.Adapter.Repositories;

/// <summary>
/// Student repository implementation
/// </summary>
public class StudentRepository : IStudentRepository, ITransient
{
    private readonly TTShangDbContext _context;

    public StudentRepository(TTShangDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get all students
    /// </summary>
    public async Task<List<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }

    /// <summary>
    /// Get student by ID
    /// </summary>
    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await _context.Students.FindAsync(id);
    }

    /// <summary>
    /// Add a new student
    /// </summary>
    public async Task<Student> AddAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    /// <summary>
    /// Update an existing student
    /// </summary>
    public async Task<Student> UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
        return student;
    }

    /// <summary>
    /// Delete a student by ID
    /// </summary>
    public async Task<bool> DeleteAsync(Guid id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return false;
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }
}
