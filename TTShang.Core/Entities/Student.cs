namespace TTShang.Core.Entities;

/// <summary>
/// Student entity
/// </summary>
public class Student
{
    /// <summary>
    /// Student ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Student name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Student age
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Student gender
    /// </summary>
    public string Gender { get; set; } = string.Empty;
}
