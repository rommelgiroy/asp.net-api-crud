using APICrud.Models;

namespace APICrud.Contracts;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudents();
    Task<Student> GetStudent(int id);
    Task CreateStudent(Student student);
    Task UpdateStudent(Student student);
    Task DeleteStudent(int id);
}
